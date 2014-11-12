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
using Cirrious.MvvmCross.Plugins.PictureChooser;
using System.IO;

namespace SurveyForms.Core.ViewModels
{
	public class ProductDetailsViewModel : MvxViewModel
	{
		private readonly IOfficeDetailsService _service;
		private readonly IMvxPictureChooserTask _pictureChooserTask;

		public ProductDetailsViewModel (IOfficeDetailsService service, IMvxPictureChooserTask pictureChooserTask)
		{
			_service = service;
			_pictureChooserTask = pictureChooserTask;
		}

		private ManifestDetail _manifestDetails;

		public ManifestDetail ManifestDetails {
			get { return _manifestDetails; }
			set { _manifestDetails = value; }
		}

		private ProductDetail _productDetails;

		public ProductDetail ProductDetails {
			get { return _productDetails; }
			set {
				_productDetails = value;
				RaisePropertyChanged (() => ProductDetails);
			}
		}

		public ICommand HandleAddPicture {
			get { 
				//return new MvxCommand (()=>{});
				return new MvxCommand (
					() => {
						_pictureChooserTask
							.ChoosePictureFromLibrary (800, 95, 
								((System.IO.Stream stream) => {
									var memstream = new MemoryStream ();
									stream.CopyTo (memstream);
									PictureBytes = memstream.ToArray ();

									var result = _service.UploadPicture(PictureBytes,"","","NewFile");
									if(result)
									{

									}
									else
									{

									}

								}), () => {
								});
					});
			}

		}

		private byte[] _picturebytes;

		public byte[] PictureBytes {
			get { return _picturebytes; }
			set {
				_picturebytes = value;
				RaisePropertyChanged (() => PictureBytes);
			}
		}


		public ICommand HandleShowPictures {
			get { 
				return new MvxCommand (() => {
				});
			}

		}

		public ICommand HandleShowVisits {
			get { 
				return new MvxCommand (() => {
				});
			}

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