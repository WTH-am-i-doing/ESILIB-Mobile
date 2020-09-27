using ESILib.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if(App.Current.Properties.ContainsKey("Intro"))
                MainPage = new MainPage();
            else
                MainPage = new Introduction();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
