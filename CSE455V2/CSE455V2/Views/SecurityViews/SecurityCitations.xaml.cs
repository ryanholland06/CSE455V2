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
        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            if (!IsLicenseValid())
            {
                await DisplayAlert("Error", "Required Field Incorrect or Missing", "Ok");
                return;
            }
            
            var person = await firebaseHelper.GetUserByLisencePlate(searchLisencePlate.Text);
            if (person != null)
            {
                if (person.NumberOfCitations >= 3)
                {
                    await DisplayAlert("Warning", "Too many violations!", "OK");
                    await Navigation.PushAsync(new SecurityViews.SecurityTow());
                    searchLisencePlate.Text = "";
                }
               else
                {
                    personName.Text = person.FirstName + " " + person.LastName;
                    vinNumber.Text = person.LicenseNumber;
                    vehicleInfo.Text = person.CarYear + " " + person.CarMake + " " + person.CarModel;
                }
            }
            else
            {
                await DisplayAlert("Error", "No Person Available", "Ok");
            }

        }
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

                //NOTIFY USER
                string subject = "Citation Alert";
                string body = "Attention " + person.FirstName + " " + person.LastName + ", \n\n Your vehicle was citated!\n"
                    + "Vehicle Information: " + vehicleInfo.Text + "\n" + "License Plate: " + searchLisencePlate.Text + "\n"
                    + "Reason for Citation: " + citationReason.SelectedItem.ToString() + "\n"
                    + "Please Pay at: LINK HERE\n For more information please contact Parking Services at 999-999-9999.";
                string email = person.Email;
                bool isSent = false;
                
                if(isSent == false)
                {
                    await Email.ComposeAsync(subject, body, email);
                    isSent = true;
                }
               else if(isSent == true)
                    await DisplayAlert("Confirmation", "Citation Submitted", "Ok");
                
                //CLEAR PAGE
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