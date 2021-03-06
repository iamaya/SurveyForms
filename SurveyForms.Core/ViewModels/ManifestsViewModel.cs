﻿using Cirrious.MvvmCross.ViewModels;
using SurveyForms.Core.Models.ViewModels;
using SurveyForms.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Worklight.Xamarin.Android;

namespace SurveyForms.Core.ViewModels
{
	public class ManifestsViewModel : MvxViewModel
	{
		private WorklightClient _client;

		public ManifestsViewModel (IManifestService service)
		{
			Task.Factory.StartNew (() => service.InvokeAPIASync ("")).ContinueWith ((results) => {
				AllManifests = results.Result.Result.manifestMasterview;
			});


		}

		private List<ManifestMasterViewModel> _allManifests;

		public List<ManifestMasterViewModel> AllManifests {
			get { return _allManifests; }
			set {
				_allManifests = value;
				RaisePropertyChanged (() => AllManifests);
			}
		}

	//	private MvxCommand _nextScreenCommand;

		public ICommand NextScreenCommand {
			get {
				// _nextScreenCommand = _nextScreenCommand ?? new MvxCommand(DoNextScreenCommand);
				//return _nextScreenCommand;
				return new MvxCommand<ManifestMasterViewModel> (item => ShowViewModel<OfficesViewModel> (new OfficesViewModel.Nav (){ Id = item.Id_ServiceZone }));
			}
		}

//		private void DoNextScreenCommand ()
//		{
//			ShowViewModel<OfficesViewModel> ();
//		}

	}
}
