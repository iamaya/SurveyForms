using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyForms.Core.Models.ViewModels
{
    public class ManifestZonesPagedViewModel
    {
        public List<ManifestMasterViewModel> manifestMasterview { get; set; }

        public List<ManifestDetail> manifestdetails { get; set; }
        public List<Status> ManifestStatu { get; set; }

        public List<Status> visitStatu { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
