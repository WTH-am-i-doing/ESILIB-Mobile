using ESILib.Pages.ProfilePages;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (App.Current.Properties.ContainsKey("User"))
                LogoutFrame.IsVisible = true;
            user.Text = App.Current.Properties.ContainsKey("User") ? (JsonConvert.DeserializeObject<UserInfo>(App.Current.Properties["User"] as string)).Email : "Login";

            img.Source = "https://dummyimage.com/400x400/"+GenerateCode(6)+"/fff&text=" + user.Text.ToUpper().First();
        }

        private string GenerateCode(int length)
        {
            const string valid = "0123456789ABCDEF";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (App.Current.Properties.ContainsKey("User"))
                await Shell.Current.Navigation.PushAsync(new ProfilePages.Profile());
            else
                await Shell.Current.Navigation.PushAsync(new Login());
        }

        private async void LogOutTapped(object sender, EventArgs e)
        {
            if(await DisplayAlert("Logging Out","Are you Sure You Want To Log Out", "Yes", "No"))
            {
                App.Current.Properties.Remove("User");
                await App.Current.SavePropertiesAsync();
                OnAppearing();
            }
        }
    }
}