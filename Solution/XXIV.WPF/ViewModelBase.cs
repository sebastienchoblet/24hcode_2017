using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace XXIV.WPF
{
	[Serializable]
	[DebuggerDisplay("{GetType().Name,nq}")]
	public class ViewModelBase : IViewModelBase, INotifyPropertyChanged, INotifyPropertyChanging
	{
		[XmlIgnore]
		public Dispatcher DispatcherBuilder { get; private set; }

		public ViewModelBase()
		{
			DispatcherBuilder = Dispatcher.CurrentDispatcher;
		}

		public event PropertyChangingEventHandler PropertyChanging;
		protected virtual void OnPropertyChanging(string sProp)
		{
			if (PropertyChanging != null)
			{
				PropertyChanging(this, new PropertyChangingEventArgs(sProp));
			}
		}


		public virtual void SetData(object o)
		{
		}
		public virtual object GetData()
		{
			return null;
		}
		protected bool _modified = false;
		public bool Modified
		{
			get { return _modified; }
			set { _modified = value; }
		}
		protected virtual void OnPropertyChanged(string sNomProp)
		{
			Modified = true;

			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(sNomProp));
		}

		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpresion)
		{
			var property = (MemberExpression)propertyExpresion.Body;
			VerifyPropertyExpression<T>(propertyExpresion, property);
			this.OnPropertyChanged(property.Member.Name);
		}

		protected void SetValue<T>(ref T refValue, T newValue, Expression<Func<T>> propertyExpresion)
		{
			if (!object.Equals(refValue, newValue))
			{
				refValue = newValue;
				this.OnPropertyChanged(propertyExpresion);
			}
		}
		protected void SetValue<T>(ref T refValue, T newValue, Action valueChanged)
		{
			if (!object.Equals(refValue, newValue))
			{
				refValue = newValue;
				valueChanged();
			}
		}

		protected string _Nom;
		public virtual string Nom
		{
			get
			{
				return _Nom;
			}
			set
			{
				if (value != _Nom)
				{
					_Nom = value;
					OnPropertyChanged(() => Nom);
				}
			}
		}

		[Conditional("DEBUG")]
		private void VerifyPropertyExpression<T>(Expression<Func<T>> propertyExpresion, MemberExpression property)
		{
			if (property.Member.GetType().IsAssignableFrom(typeof(PropertyInfo)))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
					"Invalid Property Expression {0}",
					propertyExpresion));
			}

			var instance = property.Expression as ConstantExpression;
			if (instance.Value != this)
			{

				throw new ArgumentException(
					string.Format(
					CultureInfo.CurrentCulture,
					"Invalid Property Expression {0}",
					propertyExpresion));
			}
		}

		[field: NonSerialized]
		protected List<ICommand> _Commands = new List<ICommand>();
		[XmlIgnore]
		public virtual List<ICommand> Commands
		{
			get
			{
				return _Commands;
			}
		}

		protected virtual void OnCanExecuteCommand(ICommand cmd)
		{
		}
		protected virtual void OnExecuteCommand(ICommand cmd)
		{
		}

		protected virtual bool CanAddExecute(IList coll)
		{
			return false;
		}
		protected virtual void AddExecute(IList coll)
		{

		}

		//[field: NonSerialized]
		//protected ObservableCollection<ViewModelBase> _SubVMs = null;
		//[XmlIgnore]
		//public virtual ObservableCollection<ViewModelBase> SubVMs
		//{
		//	get
		//	{
		//		if (_SubVMs == null)
		//		{
		//			_SubVMs = new List<ViewModelBase>();
		//			_SubVMs.AddElement = new RelayCommandASender<ICollectionVMBase>(_SubVMs
		//				, new Action<IList>(AddExecute)
		//				, new Func<IList, bool>(CanAddExecute));
		//			_SubVMs.CollectionChanged += OnSubVMsCollectionChanged;
		//		}
		//		return _SubVMs;
		//	}
		//}

		//protected virtual void OnSubVMsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		//{
		//}
		//public ObservableCollection<TVM> GetChilds<TVM>(string sProperty)
		//where TVM : ViewModelBase
		//{
		//	INotifyCollectionChanged coll = null;
		//	if (!_subCollecs.TryGetValue(sProperty, out coll))
		//	{
		//		return null;
		//	}
		//	return (CollectionVM<TVM>)coll;
		//}

		//public virtual CollectionVM<TVM> FillViewModelsChilds<TVM>(string sProperty, List<object> items)
		//where TVM : ViewModelBase
		//{
		//	ICollectionVMBase coll = null;
		//	if (!_subCollecs.TryGetValue(sProperty, out coll))
		//	{
		//		CollectionVM<TVM> colltp = new CollectionVM<TVM>();
		//		colltp.AddElement = new RelayCommandASender<ICollectionVMBase>(colltp
		//				, new Action<ICollectionVMBase>(AddExecute)
		//				, new Func<ICollectionVMBase, bool>(CanAddExecute));
		//		coll = colltp;
		//		_subCollecs[sProperty] = coll;
		//		//coll.AddElement
		//		coll.CollectionChanged += OnSubCollectionChanged;
		//	}
		//	else
		//		coll.Clear();
		//	coll.Name = sProperty;
		//	ViewModelBase vm;
		//	foreach (object o in items)
		//	{
		//		vm = ViewModelFactory.Build(o);
		//		vm.PropertyChanged += OnSubItemPropertyChanged;
		//		coll.Add(vm);
		//	}
		//	return (CollectionVM<TVM>)coll;
		//}

		//public virtual void OnSubItemPropertyChanged(object sender, PropertyChangedEventArgs e)
		//{
		//}
		//public virtual CollectionVM<ViewModelBase> FillViewModelsChilds(string sProperty, List<object> items)
		//{
		//	return FillViewModelsChilds<ViewModelBase>(sProperty, items);
		//}
		//protected virtual void GetSubsItemsForFill(Dictionary<string, List<object>> dico)
		//{
		//}
		//protected virtual void OnSubCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		//{
		//	ICollectionVMBase coll = sender as ICollectionVMBase;
		//	string sProp = "";
		//	if (coll != null)
		//		sProp = coll.Name;
		//	if (e.NewItems != null)
		//		foreach (ViewModelBase vm in e.NewItems)
		//			if (!SubVMs.Contains(vm))
		//			{
		//				OnAddSubVM(sProp, vm, false);
		//			}
		//	if (e.OldItems != null)
		//		foreach (ViewModelBase vm in e.OldItems)
		//			if (SubVMs.Contains(vm))
		//			{
		//				OnRemoveSubVM(sProp, vm);
		//			}
		//}

		//protected virtual void OnAddSubVM(string sProp, ViewModelBase add, bool bInit)
		//{
		//	add.PropertyChanged += OnSubItemPropertyChanged;
		//	SubVMs.Add(add);
		//}
		//protected virtual void OnRemoveSubVM(string sProp, ViewModelBase remove)
		//{
		//	remove.PropertyChanged -= OnSubItemPropertyChanged;
		//	SubVMs.Remove(remove);
		//}
		//protected ICollectionVMBase GetColl(string sProperty)
		//{
		//	ICollectionVMBase coll = null;
		//	if (_subCollecs.TryGetValue(sProperty, out coll))
		//		return coll;
		//	return null;
		//}
		//protected ICollectionVM<TVM> GetCollection<TVM>(string sProperty)
		//	where TVM : ViewModelBase
		//{
		//	ICollectionVMBase c = GetColl(sProperty);
		//	if (c != null && typeof(ICollectionVM<TVM>).IsAssignableFrom(c.GetType()))
		//		return (ICollectionVM<TVM>)c;
		//	return null;
		//}

		//[field: NonSerialized]
		//protected Dictionary<string, IList> _subCollecs = new Dictionary<string, IList>();


		////A voir... liste d'élément plutot...
		//[field: NonSerialized]
		//private FrameworkElement _Element;
		//[XmlIgnore]
		//public virtual FrameworkElement WPFItem
		//{
		//	get
		//	{
		//		return _Element;
		//	}
		//	set
		//	{
		//		if (value != _Element)
		//		{
		//			OnUnfillElement();
		//			_Element = value;
		//			OnFillElement();
		//		}
		//	}
		//}
		//protected virtual void OnUnfillElement()
		//{
		//}
		//protected virtual void OnFillElement()
		//{
		//}

		//protected static Dictionary<object, ViewModelBase> _mapp = new Dictionary<object, ViewModelBase>();
		//public static Dictionary<object, ViewModelBase> MappingMVVM
		//{
		//	get
		//	{
		//		return _mapp;
		//	}
		//}
	}
	public interface IViewModelBase
	{
	}

	[Serializable]
	public class ViewModelBase<TObject> : ViewModelBase
		where TObject : class
	{
		public ViewModelBase()
		{
		}
		public ViewModelBase(TObject data)
		{
			Data = data;
		}

		public override void SetData(object o)
		{
			Data = (TObject)o;
		}
		public override object GetData()
		{
			return Data;
		}

		public virtual ObservableCollection<ViewModelBase> LinkedObject(string sContext)
		{
			return new ObservableCollection<ViewModelBase>();
		}

		protected TObject _Data;
		public virtual TObject Data
		{
			get
			{
				return _Data;
			}
			set
			{
				if (_Data != value)
				{
					OnUnFillData();
					_Data = value;
					OnFillData();
					OnPropertyChanged("Data");
				}
			}
		}
		protected virtual void OnUnFillData()
		{
			if (Data != null)
				_mapp[Data] = null;
			foreach (INotifyCollectionChanged coll in _subCollecs.Values)
				coll.CollectionChanged -= OnSubCollectionChanged;
			SubVMs.Clear();
			_subCollecs.Clear();
		}
		protected virtual void OnFillData()
		{
			if (Data != null)
			{
				Dictionary<string, List<object>> lst = new Dictionary<string, List<object>>();
				GetSubsItemsForFill(lst);
				foreach (string sKey in lst.Keys)
					FillViewModelsChilds(sKey, lst[sKey]);
				_mapp[Data] = this;
			}
		}
	}
}
