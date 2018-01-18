using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XXIV.Web.Models
{
	public class BugViewModel
	{
		public string Nom { get; set; }
	}
	public class ListeBugsViewModels
    {

		public List<BugViewModel> Bugs { get; set; }

        [Display(Name = "Courrier électronique")]
        public string Email { get; set; }
    }

}
