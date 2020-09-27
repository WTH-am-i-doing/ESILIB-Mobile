using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Introduction : ContentPage
    {
        private List<CardViewModel> cards = new List<CardViewModel> { 
            new CardViewModel() {Title="The Catalogue In The Palm Of Your Hand",Description="Check All The Books Available In The Library And Decide Which Ones You Like And Which Ones you Don't",ImageUrl="https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/carouselview/populate-data-images/indicators-large.png" },
            new CardViewModel() {Title="Offline Catalogue",Description="We Give You The Ability To Check All The Catalogue Offline And Anywhere",ImageUrl="https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/carouselview/populate-data-images/indicators-large.png" },
            new CardViewModel() {Title="Preview And Request",Description="You Can Preview Most Of The Books Available In The Catalgoue And Once You Like One ou Can Request It",ImageUrl="https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/carouselview/populate-data-images/indicators-large.png" } };
        public Introduction()
        {
            InitializeComponent();
            Carousel.ItemsSource = cards;
        }

        private async void SkipButton_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties.Add("Intro", true);
            await App.Current.SavePropertiesAsync();
            App.Current.MainPage = new MainPage();
        }
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            if (Carousel.Position != (cards.Count() -1))
            {
                Carousel.Position++;

                if (Carousel.Position == (cards.Count()-1))
                    ((Button)sender).Text = "Finish";
                else
                    ((Button)sender).Text = "Next";
            }
            else
            {
                SkipButton_Clicked(null, null);
            }
            
        }
    }
    class CardViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}