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
    public partial class IntroView : ContentView
    {

        public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(IntroView), string.Empty);
        public static readonly BindableProperty CardDescriptionProperty = BindableProperty.Create(nameof(CardDescription), typeof(string), typeof(IntroView), string.Empty);
        public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(nameof(IconImageSource), typeof(ImageSource), typeof(IntroView), default(ImageSource));

        public string CardTitle
        {
            get => (string)GetValue(IntroView.CardTitleProperty);
            set => SetValue(IntroView.CardTitleProperty, value);
        }

        public string CardDescription
        {
            get => (string)GetValue(IntroView.CardDescriptionProperty);
            set => SetValue(IntroView.CardDescriptionProperty, value);
        }

        public ImageSource IconImageSource
        {
            get => (ImageSource)GetValue(IntroView.IconImageSourceProperty);
            set => SetValue(IntroView.IconImageSourceProperty, value);
        }

        public IntroView()
        {
            InitializeComponent();
        }
    }
}