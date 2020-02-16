using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSE455V2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageParkingPage : ContentPage
    {
        public ManageParkingPage()
        {
            InitializeComponent();
        }

        void CreateCit_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CitationsPage());
        }
    }
}