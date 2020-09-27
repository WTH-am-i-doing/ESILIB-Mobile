using ESILib.Data;
using ESILib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private FirebaseHelper helper = new FirebaseHelper();
        private ObservableCollection<Book> books ;
        public Home()
        {
            InitializeComponent();
            GetLatest();
        }
        private async void GetLatest()
        {
            books = new ObservableCollection<Book>(await helper.GetLatestBooks());
            Books.ItemsSource = books.Take(7);
        }
    }
}