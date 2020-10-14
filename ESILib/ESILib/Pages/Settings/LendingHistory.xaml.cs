using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESILib.Pages.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LendingHistory : ContentPage
    {
        public LendingHistory()
        {
            InitializeComponent();
            Title = "Lending History";
        }
    }
}