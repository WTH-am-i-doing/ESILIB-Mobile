using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSmallView : ContentView
    {
        public UserSmallView()
        {
            InitializeComponent();
            img.Source = App.Current.Properties.ContainsKey("UserPicture")?App.Current.Properties["UserPicture"] as String:"";
            user.Text = App.Current.Properties.ContainsKey("UserName") ? App.Current.Properties["UserName"] as String : "Login";
        }
    }
}