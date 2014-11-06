using Cirrious.MvvmCross.ViewModels;
using SurveyForms.Core.Models.ViewModels;
using SurveyForms.Core.Models;
using SurveyForms.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyForms.Core.ViewModels
{
    public class OfficeDetailsViewModel : MvxViewModel
    {
        public OfficeDetailsViewModel(IOfficeDetailsService service)
        {
            Task.Factory.StartNew(() => service.InvokeAPIASync(""))
                .ContinueWith((results) =>
                {
                    AllOfficeDetails = results.Result.Result;
                });
        }

        private ManifestDetail _allOfficeDetails;
        public ManifestDetail AllOfficeDetails
        {
            get { return _allOfficeDetails; }
            set { _allOfficeDetails= value; RaisePropertyChanged(() => AllOfficeDetails); }
        }
    }
}
