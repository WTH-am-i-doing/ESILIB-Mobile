using ESILib.Data;
using ESILib.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib
{
    public partial class App : Application
    {
        static LiteDBHelper db;

        public static LiteDBHelper LiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new LiteDBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Books.db"));
                }
                return db;
            }
        }

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
