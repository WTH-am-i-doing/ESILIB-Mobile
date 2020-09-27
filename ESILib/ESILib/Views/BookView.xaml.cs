using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookView : ContentView
    {

        /*public static readonly BindableProperty BookTitleProperty = BindableProperty.Create(nameof(BookTitle), typeof(string), typeof(BookView), string.Empty);
        public static readonly BindableProperty BookAuthorProperty = BindableProperty.Create(nameof(BookAuthor), typeof(string), typeof(BookView), string.Empty);
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(BookView),string.Empty);

        public string BookTitle
        {
            get => (string)GetValue(BookView.BookTitleProperty);
            set => SetValue(BookView.BookTitleProperty, value);
        }

        public string BookAuthor
        {
            get => (string)GetValue(BookView.BookAuthorProperty);
            set => SetValue(BookView.BookAuthorProperty, value);
        }

        public string ImageSource
        {
            get => (string)GetValue(BookView.ImageSourceProperty);
            set => SetValue(BookView.ImageSourceProperty, value);
        }
*/
        public BookView()
        {
            InitializeComponent();
        }
    }
}