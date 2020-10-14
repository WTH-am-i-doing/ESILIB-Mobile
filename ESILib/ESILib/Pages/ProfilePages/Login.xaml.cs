using ESILib.AppConstant;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Pages.ProfilePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            BackgroundImageSource = "https://images.pexels.com/photos/3747505/pexels-photo-3747505.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500";
        }

        async void LoginMethod(string useremail, string password)
        {
            var p2 = useremail.Split('@')[1];
            if (!p2.Equals("esi-sba.dz"))
            {
                await DisplayAlert("Error", "You Are Not From ESI_SBA", "OK");
                return;
            }

            var config = new FirebaseAuthConfig
            {
                ApiKey = Constants.Apikey,
                AuthDomain = Constants.Authdomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider(),
                },
            };

            // ...and create your FirebaseAuthClient
            var client = new FirebaseAuthClient(config);
            //var userCredential = await client.CreateUserWithEmailAndPasswordAsync("email", "pwd", "Display Name");
            try
            {
                var userCredential = await client.SignInWithEmailAndPasswordAsync(useremail, password);
                App.Current.Properties.Add("User", JsonConvert.SerializeObject(userCredential.User.Info));
                await App.Current.SavePropertiesAsync();
            }
            catch
            {
                await DisplayAlert("Error", "Check Your Password And EMail Again, And Verify You Are Connected To The Internet", "Ok");
            }
        }

        async Task RegisterMethod(string useremail, string password,string name)
        {
            var p2 = useremail.Split('@')[1];
            if (!p2.Equals("esi-sba.dz"))
            {
                await DisplayAlert("Error", "Wrong Email", "OK");
                return;
            }

            var config = new FirebaseAuthConfig
            {
                ApiKey = Constants.Apikey,
                AuthDomain = Constants.Authdomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider(),
                },
            };

            // ...and create your FirebaseAuthClient
            var client = new FirebaseAuthClient(config);
            //
            try
            {
                var userCredential = await client.CreateUserWithEmailAndPasswordAsync(useremail,password,name);
                App.Current.Properties.Add("User", JsonConvert.SerializeObject(userCredential.User.Info));
                await App.Current.SavePropertiesAsync();
            }
            catch
            {
                await DisplayAlert("Error", "Check Your Internet Connection", "Ok");
            }
        }

        private async void LoginButton(object sender, EventArgs e)
        {
            LoginMethod(useremail.Text, userpass.Text);
            await Shell.Current.Navigation.PopAsync();
        }

        private async void RegisterButton(object sender, EventArgs e)
        {
            await RegisterMethod(useremailreg.Text, userpassreg.Text, username.Text);
            tabview.SelectedIndex -= 1;
        }
    }
}