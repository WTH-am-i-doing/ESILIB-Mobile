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
        public BookDetails(Book book)
        {
            InitializeComponent();
            BindingContext = book;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopModalAsync();
        }

        private void Fav_Clicked(object sender, EventArgs e)
        {

        }

    }
}