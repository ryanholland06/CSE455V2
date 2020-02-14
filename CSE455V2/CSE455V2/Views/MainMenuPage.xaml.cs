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
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        void ParkCar_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ParkCarPage());
        }

        void MapView_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MapViewPage());
        }

        void ListView_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ListViewPage());
        }

        void Settings_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new UserSettingsPage());
        }

        void ComPost_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CommunityPostingPage());
        }

    }
}