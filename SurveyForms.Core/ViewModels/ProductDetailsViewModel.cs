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
    public class ProductDetailsViewModel : MvxViewModel
    {
		private readonly IOfficeDetailsService _service;


		public ProductDetailsViewModel(IOfficeDetailsService service)
		{
			_service = service;
		}

		private ManifestDetail _manifestDetails;
		public ManifestDetail ManifestDetails
        {
			get { return _manifestDetails; }
			set { _manifestDetails= value; }
        }

		private ProductDetail _productDetails;
		public ProductDetail ProductDetails
		{
			get { return _productDetails; }
			set { _productDetails= value; RaisePropertyChanged(() => ProductDetails); }
		}
			
		public class Nav
		{
			public int Id {
				get;
				set;
			}

			public int Id_ManifestDetail {
				get;
				set;
			}

//			public ProductDetail productDetail {
//				get;
//				set;
//			}
		}

		public void Init (Nav navigation)
		{
			Task.Factory.StartNew (() => _service.InvokeAPIASync (navigation.Id_ManifestDetail.ToString ()))
				.ContinueWith ((results) => {
					ManifestDetails = results.Result.Result;
					ProductDetails = ManifestDetails.ProductDetails.Find (item => item.ID == navigation.Id);
				});


		}
    }
}
