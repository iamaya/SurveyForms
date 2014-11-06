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
        public OfficesViewModel(IOfficesService service)
        {
            Task.Factory.StartNew(() => service.InvokeAPIASync(""))
                .ContinueWith((results) =>
                {
                    AllOffices = results.Result.Result.manifestdetails;
                });
        }

        private List<ManifestDetail> _allOffices;
        public List<ManifestDetail> AllOffices
        {
            get { return _allOffices; }
            set { _allOffices = value; RaisePropertyChanged(() => AllOffices); }
        }

        private MvxCommand _nextScreenCommand;

        public ICommand NextScreenCommand
        {
            get
            {
                _nextScreenCommand = _nextScreenCommand ?? new MvxCommand(DoNextScreenCommand);
                return _nextScreenCommand;
            }
        }

        private void DoNextScreenCommand()
        {
            ShowViewModel<OfficeDetailsViewModel>();
        }
    }
}
