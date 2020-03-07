using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSE455V2.Views.SecurityViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecurityMainMenu : ContentPage
    {
        public SecurityMainMenu()
        {
            InitializeComponent();
        }

        public async void OnButtonClickedParkingLot(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecurityViewParkingLot());
        }

        public async void OnNewSwipeItemInvoke(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecurityViews.SecurityCitations());
        }

        public async void OnButtonClickedTowing(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecurityViews.SecurityTow());
        }

        public async void OnButtonClickedAlerts(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecurityViews.SecurityAlerts());
        }

        public async void OnSearchSwipeItemInvoke(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecurityViews.CitationsSearch());
        }
    }
}