using Newtonsoft.Json;
using SurveyForms.Core.Models.ViewModels;
using SurveyForms.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SurveyForms.Core.Helpers;

namespace SurveyForms.Core.Services
{
    public class OfficeDetailsService : IOfficeDetailsService
    {
        public OfficeDetailsService()
        {

        }

        public static string APIKey { get { return "ahWebsite"; } }
        public static string APIPwd { get { return "86rJw9s4xDAN2YzUCfz7+A=="; } }

        public static Uri BaseUri { get { return new Uri("http://ahphotoservice.azurewebsites.net/"); } }

        public async Task<ManifestDetail> InvokeAPIASync(string data)
        {
			var url = "api/ManifestDetails/GetManifestDetails/48d71237-e8a1-453e-9694-1384691f7a02!!System Administrator!!" + data;

            var client = new HttpClient(
                     new HttpClientHandler
                     {
                         Credentials = new System.Net.NetworkCredential
                         {
                             UserName = APIKey,
                             Password = APIPwd
                         }
                     });

            client.BaseAddress = BaseUri;

            var response = await client.GetAsync(url);

            var returnJson = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ManifestDetail>(returnJson);
        }

		public bool UploadPicture(byte[] picturestream, string metadata, string info, string filename)	
		{
			BlobHelper blobHelper = new BlobHelper ();
			blobHelper.UploadToBlob (picturestream, filename);

			return true;
		}
    }
}
