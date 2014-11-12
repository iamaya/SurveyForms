using SurveyForms.Core.Models;
using SurveyForms.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyForms.Core.Services
{
    public interface IOfficeDetailsService
    {
        Task<ManifestDetail> InvokeAPIASync(string data);
		bool UploadPicture (byte[] picturestream, string metadata, string info, string filename);
    }
}
