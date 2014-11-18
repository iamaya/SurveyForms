﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Worklight.Xamarin.Android;


namespace WorklightSample.Android
{
	[Activity (Label = "Worklight Sample", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);

			App.WorklightClient =  new SampleClient ( WorklightClient.CreateInstance (this));

			SetPage (App.GetMainPage ());
		}
	}
}

