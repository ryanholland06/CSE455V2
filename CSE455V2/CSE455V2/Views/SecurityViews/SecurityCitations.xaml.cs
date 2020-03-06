using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using CSE455V2.Services;

namespace CSE455V2.Views.SecurityViews
{
    public partial class SecurityCitations : ContentPage
    {
        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        public SecurityCitations()
        {
            InitializeComponent();
        }

        /*
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var person = await firebaseHelper.GetPerson(Convert.ToInt32(txtVin.Text));
            showResult.Text = person.Name;
        }
        
        public async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text, Convert.ToInt64(txtVin.Text), txtVehicle.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtVin.Text = string.Empty;
            txtVehicle.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Sucessfully", "Ok");
            //var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }
        */

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            var person = await firebaseHelper.GetUserByLisencePlate(searchLisencePlate.Text);
            if (!IsLicenseValid())
            {
                await DisplayAlert("Error", "Required Field Incorrect or Missing", "Ok");
                return;
            }
            else if (person != null)
            {
                personName.Text = person.FirstName + " " + person.LastName;
                vinNumber.Text = person.LicenseNumber;
                vehicleInfo.Text = person.CarYear + " " + person.CarMake + " " + person.CarModel;

                //lstPerson.ItemsSource = person.Name;
                //await DisplayAlert("Sucess", "Person Retrieve Successfully", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "No Person Available", "Ok");
            }
        }
        /*
        public async void OnButtonClickAddCitation(object sender, EventArgs e)
        {
            if (citationReason.SelectedItem == null)
            {
                await DisplayAlert("Error", "Required Field Incorrect or Missing", "Ok");
                return;
            }
            else
            {
                var person = await firebaseHelper.GetPerson(searchLisencePlate.Text);
                await firebaseHelper.AddCitation(vehicleInfo.Text,
                                                 searchLisencePlate.Text,
                                                 person.PersonId,
                                                 personName.Text,
                                                 citationReason.SelectedItem.ToString());

                //NAVIGATE TO PREVIOUS PAGE

                await DisplayAlert("Confirmation", "Citation Submitted", "Ok");
            }
        }
        */
        
        public async void OnButtonClickAddCitation(object sender, EventArgs e)
        {
            if (citationReason.SelectedItem == null)
            {
                await DisplayAlert("Error", "Required Field Incorrect or Missing", "Ok");
                return;
            }
            else
            {
                var person = await firebaseHelper.GetUserByLisencePlate(searchLisencePlate.Text);
                await firebaseHelper.AddCitation(vehicleInfo.Text,
                                                 searchLisencePlate.Text,
                                                 person.StudentID,
                                                 personName.Text,
                                                 citationReason.SelectedItem.ToString());

                await DisplayAlert("Confirmation", "Citation Submitted", "Ok");
                searchLisencePlate.Text = "";
                vehicleInfo.Text = "";
                personName.Text = "";
                vinNumber.Text = "";
                citationReason.SelectedIndex = -1;
            }
        }

        private bool IsLicenseValid() => IsLicenseLengthValid() && !string.IsNullOrWhiteSpace(searchLisencePlate.Text);

        private bool IsLicenseLengthValid() => searchLisencePlate.Text.Length >= 2 && searchLisencePlate.Text.Length <= 7;
    }
}