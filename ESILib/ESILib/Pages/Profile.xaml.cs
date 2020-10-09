using ESILib.Pages.ProfilePages;
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

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (App.Current.Properties.ContainsKey("UserName"))
                await Shell.Current.Navigation.PushAsync(new ProfilePages.Profile());
            else
                await Shell.Current.Navigation.PushAsync(new Login());
        }
    }
}