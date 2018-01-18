using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XXIV.WPF
{

	public class RelayCommand : ICommand
	{
		#region private fields
		private readonly Action execute;
		private readonly Func<bool> canExecute;
		private readonly Action<object> executepara;
		private readonly Func<object, bool> canExecutepara;
		#endregion

		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (this.canExecute != null)
					CommandManager.RequerySuggested += value;
			}
			remove
			{
				if (this.canExecute != null)
					CommandManager.RequerySuggested -= value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the RelayCommand class
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		public RelayCommand(Action execute)
			: this(execute, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the RelayCommand class
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		/// <param name="canExecute">The execution status logic.</param>
		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");

			this.execute = execute;
			this.canExecute = canExecute;
		}
		public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
		{
			this.executepara = execute;
			this.canExecutepara = canExecute;
		}

		public void Execute(object parameter)
		{
			if (execute != null)
				this.execute();
			else
				executepara(parameter);
		}

		public bool CanExecute(object parameter)
		{
			if (canExecute != null)
				return this.canExecute();
			else if (canExecutepara != null)
				return this.canExecutepara(parameter);
			return true;
		}
	}



	public class RelayCommandASender<TSender> : ICommand
	{
		#region private fields
		private TSender Sender { get; set; }
		private readonly Action<TSender> execute;
		private readonly Func<TSender, bool> canExecute;
		private readonly Action<TSender, object> executepara;
		private readonly Func<TSender, object, bool> canExecutepara;
		#endregion

		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (this.canExecute != null)
					CommandManager.RequerySuggested += value;
			}
			remove
			{
				if (this.canExecute != null)
					CommandManager.RequerySuggested -= value;
			}
		}

		/// <summary>
		/// Initializes a new instance of the RelayCommand class
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		public RelayCommandASender(TSender sender, Action<TSender> execute)
			: this(sender, execute, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the RelayCommand class
		/// </summary>
		/// <param name="execute">The execution logic.</param>
		/// <param name="canExecute">The execution status logic.</param>
		public RelayCommandASender(TSender sender, Action<TSender> execute, Func<TSender, bool> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");

			this.Sender = sender;
			this.execute = execute;
			this.canExecute = canExecute;
		}
		public RelayCommandASender(TSender sender, Action<TSender, object> execute, Func<TSender, object, bool> canExecute)
		{
			this.Sender = sender;
			this.executepara = execute;
			this.canExecutepara = canExecute;
		}

		public void Execute(object parameter)
		{
			if (execute != null)
				this.execute(Sender);
			else
				executepara(Sender, parameter);
		}

		public bool CanExecute(object parameter)
		{
			if (canExecute != null)
				return this.canExecute(Sender);
			else if (canExecutepara != null)
				return this.canExecutepara(Sender, parameter);
			return true;
		}
	}
}
