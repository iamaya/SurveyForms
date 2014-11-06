using SurveyForms.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyForms.Core.Services
{
    public interface IManifestService
    {
        Task<ManifestZonesPagedViewModel> InvokeAPIASync(string data);
    }
}
