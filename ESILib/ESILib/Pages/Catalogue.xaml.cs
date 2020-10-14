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
        private ObservableCollection<Book> GetBooks;
        public Catalogue()
        {
            InitializeComponent();
            OnLaunch();
        }
        private async void OnLaunch()
        {
            try
            {
                GetBooks = new ObservableCollection<Book>(await helper.GetAllBooks());
                bookList.ItemsSource = new ObservableCollection<Book>(GetBooks);
                foreach (var bok in GetBooks)
                {
                    if (App.LiteDB.Bks.FindOne(b => b.ISBN == bok.ISBN) == null)
                    {
                        App.LiteDB.Bks.Insert(bok);
                    }
                }
            }
            catch
            {
                //await DisplayAlert("Error","Check Your Internet Connection To Get All The Available Books","Ok");
                bookList.ItemsSource = new ObservableCollection<Book>(App.LiteDB.Bks.FindAll());
            }
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            OnLaunch();
            ((RefreshView)sender).IsRefreshing = false;
        }

        private async void bookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book book = ((CollectionView)sender).SelectedItem as Book;
            ((CollectionView)sender).SelectedItem = null;
            if (book != null)
                await Shell.Current.Navigation.PushModalAsync(new BookDetails(book));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            bookList.ItemsSource = GetBooks.Where(b=>(b.Title +" " +b.Description+" " + b.Author).ToLower().Contains(e.NewTextValue.ToLower()));
        }
    }
}