using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using ESILib.AuthHelpers;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ESILib.Droid
{
	[Activity(Label = "CustomUrlSchemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
	[IntentFilter(
	new[] { Intent.ActionView },
	Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
	DataSchemes = new[] { "com.googleusercontent.apps.930307352604-6nal61bs0qjmu5bdq5lak3m0nper8jl2" },
	DataPath = "/oauth2redirect")]
	public class CustomUrlSchemeInterceptorActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Convert Android.Net.Url to Uri
			var uri = new Uri(Intent.Data.ToString());

            // Load redirectUrl page
            AuthenticationState.Authenticator.OnPageLoading(uri);

			Finish();
		}
	}
}