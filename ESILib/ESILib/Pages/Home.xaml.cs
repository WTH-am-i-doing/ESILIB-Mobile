using ESILib.Data;
using ESILib.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        private FirebaseHelper helper = new FirebaseHelper();
        private ObservableCollection<Book> books ;
        private ObservableCollection<Book> collectbooks;
        public Home()
        {
            InitializeComponent();
            GetLatest();
        }
        private async void GetLatest()
        {
            try
            {
                books = new ObservableCollection<Book>(await helper.GetLatestBooks());
                collectbooks = new ObservableCollection<Book>(books.Reverse().Take(4));
                Books.ItemsSource = books.Where(i => !collectbooks.Contains(i));
                First.ItemsSource = collectbooks;
                foreach (var bok in books)
                {
                    if (App.LiteDB.Bks.FindOne(b => b.ISBN == bok.ISBN) == null)
                    {
                        App.LiteDB.Bks.Insert(bok);
                    }
                }
            }
            catch
            {
                books = new ObservableCollection<Book>(App.LiteDB.Bks.FindAll().Take(10));
                collectbooks = new ObservableCollection<Book>(books.Take(4));
                Books.ItemsSource = books.Where(i => !collectbooks.Contains(i));
                First.ItemsSource = collectbooks;
            }
        }

        private async void First_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book book = ((CollectionView)sender).SelectedItem as Book;
            ((CollectionView)sender).SelectedItem = null;
            if(book != null)
                await Shell.Current.Navigation.PushModalAsync(new BookDetails(book));
        }

        private async void Books_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Book book = (Book)e.Item;
            await Shell.Current.Navigation.PushModalAsync(new BookDetails(book));
        }

        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            GetLatest();
            ((RefreshView)sender).IsRefreshing = false;
        }
    }
}