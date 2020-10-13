using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using ESILib.Models;
using Newtonsoft.Json;
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
            if (App.Current.Properties.ContainsKey("User") && !App.Current.Properties.ContainsKey("RqKey"))
                Requesting.IsVisible = true;
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

        private async void Requesting_Clicked(object sender, EventArgs e)
        {
            var user = Newtonsoft.Json.JsonConvert.DeserializeObject<Firebase.Auth.UserInfo>(App.Current.Properties["User"] as string);
            try
            {
                var rqkey = await (new ESILib.Data.FirebaseHelper()).AddRequest(new Request() { BookISBN = book.ISBN, BookTitle = book.Title, dateTime = DateTime.Now, UserEmail = user.Email });
                // Display An Indication That The Request Has Been Sent
                App.Current.Properties.Add("RqKey",JsonConvert.SerializeObject(rqkey));
                await App.Current.SavePropertiesAsync();
                Requesting.IsEnabled = false;
                UserDialogs.Instance.Toast("The Request Has Been Sent You Check Its Status In The Settings Page");
            }
            catch
            {
                await DisplayAlert("Error", "There Has Been An Error Check Your Internet Connection And Check Again", "OK");
            }
        }
    }
}