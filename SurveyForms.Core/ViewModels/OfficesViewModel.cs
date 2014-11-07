using Cirrious.MvvmCross.ViewModels;
using SurveyForms.Core.Models.ViewModels;
using SurveyForms.Core.Models;
using SurveyForms.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SurveyForms.Core.ViewModels
{
	public class OfficesViewModel : MvxViewModel
	{
		private readonly IOfficesService _service;

		public OfficesViewModel (IOfficesService service)
		{
			_service = service;
		}

		private List<ManifestDetail> _allOffices;

		public List<ManifestDetail> AllOffices {
			get { return _allOffices; }
			set {
				_allOffices = value;
				RaisePropertyChanged (() => AllOffices);
			}
		}

		private MvxCommand _nextScreenCommand;

		public ICommand NextScreenCommand {
			get {
				_nextScreenCommand = _nextScreenCommand ?? new MvxCommand (DoNextScreenCommand);
				return _nextScreenCommand;
			}
		}

		private void DoNextScreenCommand ()
		{
			ShowViewModel<OfficeDetailsViewModel> ();
		}
			
		public class Nav
		{
			public int Id {
				get;
				set;
			}
		}

		public void Init (Nav navigation)
		{

			Task.Factory.StartNew(() => _service.InvokeAPIASync(navigation.Id.ToString()))
			                .ContinueWith((results) =>
			                {
			                    AllOffices = results.Result.Result.manifestdetails;
			                });

		//	_service.InvokeAPIASync (navigation.Id.ToString());

		}
	}
}
