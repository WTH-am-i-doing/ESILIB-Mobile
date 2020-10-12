using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESILib.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetails : ContentPage
    {
        private readonly Book book;

        public BookDetails(Book book)
        {
            InitializeComponent();
            BindingContext = book;
            this.book = App.LiteDB.Bks.FindOne(b => b.ISBN == book.ISBN);
            Fav.TextColor = this.book.isFavorite ? Color.Red : Color.Gray;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopModalAsync();
        }

        private void Fav_Clicked(object sender, EventArgs e)
        {
            book.isFavorite =! book.isFavorite;
            App.LiteDB.Bks.Update(book);
            Fav.TextColor = book.isFavorite ? Color.Red : Color.Gray;
        }

    }
}