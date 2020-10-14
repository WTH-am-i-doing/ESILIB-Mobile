using ESILib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Pages.ProfilePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorites : ContentPage
    {
        public Favorites()
        {
            InitializeComponent();
            Title = "Favourites";
            bookList.ItemsSource = new ObservableCollection<Book>(App.LiteDB.Bks.Find(b=>b.isFavorite).ToList());
        }

        private async void bookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Book book = ((CollectionView)sender).SelectedItem as Book;
            ((CollectionView)sender).SelectedItem = null;
            if (book != null)
                await Shell.Current.Navigation.PushModalAsync(new BookDetails(book));

        }
    }
}