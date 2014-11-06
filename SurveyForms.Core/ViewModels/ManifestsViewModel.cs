using Cirrious.MvvmCross.ViewModels;
using SurveyForms.Core.Models.ViewModels;
using SurveyForms.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyForms.Core.ViewModels
{
    public class ManifestsViewModel : MvxViewModel
    {
        public ManifestsViewModel(IManifestService service)
        {
            Task.Factory.StartNew(() => service.InvokeAPIASync("")).ContinueWith((results) =>
            {
                AllManifests = results.Result.Result.manifestMasterview;
            });
        }

        private List<ManifestMasterViewModel> _allManifests;
        public List<ManifestMasterViewModel> AllManifests
        { 
            get { return _allManifests; }
            set { _allManifests = value; RaisePropertyChanged(() => AllManifests); }
        }
    }
}
