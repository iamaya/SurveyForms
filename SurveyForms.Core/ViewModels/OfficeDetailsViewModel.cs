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
    public class OfficeDetailsViewModel : MvxViewModel
    {
		private readonly IOfficeDetailsService _service;


        public OfficeDetailsViewModel(IOfficeDetailsService service)
        {
			_service = service;
        }

        private ManifestDetail _allOfficeDetails;
        public ManifestDetail AllOfficeDetails
        {
            get { return _allOfficeDetails; }
            set { _allOfficeDetails= value; RaisePropertyChanged(() => AllOfficeDetails); }
        }


		public class Nav
		{
			public int Id {
				get;
				set;
			}

		}

		public ICommand NextScreenCommand {
			get {
				return new MvxCommand<ProductDetail> 
					(item => ShowViewModel<ProductDetailsViewModel> 
						(new ProductDetailsViewModel.Nav ()
							{ Id = item.ID, Id_ManifestDetail = item.ID_ManifestDetail}));
			}
		}


		public void Init (Nav navigation)
		{
			Task.Factory.StartNew (() => _service.InvokeAPIASync (navigation.Id.ToString ()))
				.ContinueWith ((results) => {
					AllOfficeDetails = results.Result.Result;
				});
		}

    }
}
