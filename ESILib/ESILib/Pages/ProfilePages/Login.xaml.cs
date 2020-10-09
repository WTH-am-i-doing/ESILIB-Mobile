using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ESILib.AppConstant;
using ESILib.AuthHelpers;

namespace ESILib.Pages.ProfilePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
		Account account;
		AccountStore store;
		public Login()
        {
            InitializeComponent();
			store = AccountStore.Create();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
			string clientId = null;
			string redirectUri = null;

			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					clientId = AppConstant.Constants.iOSClientId;
					redirectUri = AppConstant.Constants.iOSRedirectUrl;
					break;

				case Device.Android:
					clientId = AppConstant.Constants.AndroidClientId;
					redirectUri = AppConstant.Constants.AndroidRedirectUrl;
					break;
			}

			account = store.FindAccountsForService(AppConstant.Constants.AppName).FirstOrDefault();

			var authenticator = new OAuth2Authenticator(
				clientId,
				null,
				AppConstant.Constants.Scope,
				new Uri(AppConstant.Constants.AuthorizeUrl),
				new Uri(redirectUri),
				new Uri(AppConstant.Constants.AccessTokenUrl),
				null,
				true);

			authenticator.Completed += OnAuthCompleted;
			authenticator.Error += OnAuthError;

			AuthenticationState.Authenticator = authenticator;

			var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
			presenter.Login(authenticator);

		}
		async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
		{
			var authenticator = sender as OAuth2Authenticator;
			if (authenticator != null)
			{
				authenticator.Completed -= OnAuthCompleted;
				authenticator.Error -= OnAuthError;
			}

			User user = null;
			if (e.IsAuthenticated)
			{
				// If the user is authenticated, request their basic user data from Google
				// UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
				var request = new OAuth2Request("GET", new Uri(AppConstant.Constants.UserInfoUrl), null, e.Account);
				var response = await request.GetResponseAsync();
				if (response != null)
				{
					// Deserialize the data and store it in the account store
					// The users email address will be used to identify data in SimpleDB
					string userJson = await response.GetResponseTextAsync();
					user = JsonConvert.DeserializeObject<User>(userJson);
				}

				if (user != null)
				{
					App.Current.MainPage = new NavigationPage(new Login());

				}
				App.Current.Properties.Add("User",  JsonConvert.SerializeObject(user));
				App.Current.Properties.Add("UserName" ,user.Name);
				App.Current.Properties.Add("UserEmail",user.Email);
				App.Current.Properties.Add("UserPicture",user.Picture);
				await App.Current.SavePropertiesAsync();
				Shell.Current.Navigation.RemovePage(this);
				await Shell.Current.Navigation.PushAsync(new Profile());
			}
		}

		void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
		{
			var authenticator = sender as OAuth2Authenticator;
			if (authenticator != null)
			{
				authenticator.Completed -= OnAuthCompleted;
				authenticator.Error -= OnAuthError;
			}

			Debug.WriteLine("Authentication error: " + e.Message);
		}
    }
}