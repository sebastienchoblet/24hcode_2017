using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using XXIV.Web.Models;

namespace XXIV.Web.Controllers
{
	//[Authorize]
	public class BugsController : Controller
	{
		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;

		public BugsController()
		{
		}

		public BugsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		public ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
			}
			private set
			{
				_signInManager = value;
			}
		}

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		//
		// GET: /Manage/Index
		//public async Task<ActionResult> Index()
		public async Task<ActionResult> Index()
		{
			//await UserManager.GetPhoneNumberAsync();
			var userId = User.Identity.GetUserId();
			ListeBugsViewModels lst = new ListeBugsViewModels();
			lst.Bugs = new System.Collections.Generic.List<BugViewModel>();
			for (int n = 0; n < 100; n++)
				lst.Bugs.Add(new BugViewModel() { Nom = n.ToString() });
			var model = lst;
			return View(model);
		}
		public virtual Task<string> GetPhoneNumberAsync()
		{
			return null;
		}


		//
		// POST: /Manage/AddPhoneNumber
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			// Générer le jeton et l'envoyer
			var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
			if (UserManager.SmsService != null)
			{
				var message = new IdentityMessage
				{
					Destination = model.Number,
					Body = "Votre code de sécurité est : " + code
				};
				await UserManager.SmsService.SendAsync(message);
			}
			return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
		}



		protected override void Dispose(bool disposing)
		{
			if (disposing && _userManager != null)
			{
				_userManager.Dispose();
				_userManager = null;
			}

			base.Dispose(disposing);
		}

		#region Programmes d'assistance
		// Utilisé pour la protection XSRF lors de l'ajout de connexions externes
		private const string XsrfKey = "XsrfId";

		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}

		private bool HasPassword()
		{
			var user = UserManager.FindById(User.Identity.GetUserId());
			if (user != null)
			{
				return user.PasswordHash != null;
			}
			return false;
		}

		private bool HasPhoneNumber()
		{
			var user = UserManager.FindById(User.Identity.GetUserId());
			if (user != null)
			{
				return user.PhoneNumber != null;
			}
			return false;
		}

		public enum ManageMessageId
		{
			AddPhoneSuccess,
			ChangePasswordSuccess,
			SetTwoFactorSuccess,
			SetPasswordSuccess,
			RemoveLoginSuccess,
			RemovePhoneSuccess,
			Error
		}

		#endregion
	}
}