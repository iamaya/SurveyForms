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

        private ManifestDetail _productDetails;
        public ManifestDetail ProductDetails
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
		}

		public void Init (Nav navigation)
		{

		}

    }
}
