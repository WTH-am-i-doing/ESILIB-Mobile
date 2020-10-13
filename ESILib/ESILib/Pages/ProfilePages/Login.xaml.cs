using ESILib.AppConstant;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        }


        async void LoginMethod(string useremail,string password)
        {
            var p2 = useremail.Split('@')[1];
            if(!p2.Equals("esi-sba.dz"))
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
                await DisplayAlert("Wrong Credentials", "Check Your Password And EMail Again", "Ok");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string email = useremail.Text;
            string pass = pswd.Text;
            LoginMethod(email, pass);
        }
    }
}