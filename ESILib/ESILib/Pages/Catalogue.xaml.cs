using ESILib.Data;
using ESILib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Catalogue : ContentPage
    {
        private FirebaseHelper helper = new FirebaseHelper();
        public Catalogue()
        {
            InitializeComponent();
            OnLaunch();
        }
        private async void OnLaunch()
        {
            try
            {
                bookList.ItemsSource = new ObservableCollection<Book>(await helper.GetAllBooks());
            }
            catch
            {
                await DisplayAlert("Error","Check Your Internet Connection","Ok");
            }
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            OnLaunch();
            ((RefreshView)sender).IsRefreshing = false;
        }
    }
}