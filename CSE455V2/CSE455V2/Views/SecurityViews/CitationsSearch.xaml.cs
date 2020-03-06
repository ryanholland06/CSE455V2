using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using CSE455V2.Services;
using CSE455V2.Models;
using CSE455V2.Views.SecurityViews;

namespace CSE455V2.Views.SecurityViews
{
    public partial class CitationsSearch : ContentPage
    {
        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        public CitationsSearch()
        {
            InitializeComponent();
        }

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            //Retrieves citations matching lisence plate info and add to citations list
            var retCit = await firebaseHelper.GetCitationsByLisencePlate(searchLisencePlate.Text);
            //SAVES ALL CITATIONS IDS INTO NEW LIST IN ORDER TO DISPLAY
            List<string> citIds = new List<string>();
            string opening = "Citation ID: ";
            foreach (var ids in retCit)
                citIds.Add(opening + ids.CitationId);

            
            if (!IsLicenseValid())
            {
                await DisplayAlert("Error", "Required Field Incorrect or Missing", "Ok");
                return;
            }
            else if (retCit != null)
            {
                //DISPLAY CITATIONS BY THEIR IDS
                CitationsListView.ItemsSource = citIds;
                await DisplayAlert("Citations Found", "Number of Citations: " + retCit.Count(), "Ok");

            }
            else
            {
                await DisplayAlert("Error", "No Person Available", "Ok");
            }

        }

        private bool IsLicenseValid() => IsLicenseLengthValid() && !string.IsNullOrWhiteSpace(searchLisencePlate.Text);

        private bool IsLicenseLengthValid() => searchLisencePlate.Text.Length >= 2 && searchLisencePlate.Text.Length <= 7;

        private async void CitationsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var retCit = await firebaseHelper.GetCitationsByLisencePlate(searchLisencePlate.Text);
            var citClicked = e.Item as string;
            string opening = "Citation ID: ";

            foreach (var clicked in retCit)
            {
                if (clicked.CitationId == Convert.ToInt64(citClicked.Substring(opening.Length, 1)))
                {
                    await Navigation.PushAsync(new SecurityViews.CitationDetails(clicked));
                    searchLisencePlate.Text = "";
                    CitationsListView.ItemsSource = null;
                }
            }

        }
    }
}