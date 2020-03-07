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

namespace CSE455V2.Views.SecurityViews
{
    public partial class SecurityTow : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public SecurityTow()
        {
            InitializeComponent();
        }

        public async void CallForATowBtnClicked(object sender, EventArgs e)
        {
            bool phoneOpened = false;

            if(searchLisencePlate.Text == " ")
            {
                await DisplayAlert("Alert", "Enter License Plate to find user", "Ok");
                return;
            }
            else if(phoneOpened == false)
            {
                PhoneDialer.Open("9999999999");
                phoneOpened = true;
            }
            
            if(phoneOpened == true)
            {
                //CREATE CALL 
                CallHistoryToTowingCompany call = new CallHistoryToTowingCompany();

                var enforcer = await FirebaseHelper.GetUser(App.UserName);

                call.EnforcerName = enforcer.FirstName + " " + enforcer.LastName;
                call.EnforcerEmail = enforcer.Email;
                call.EnforcerId = enforcer.StudentID;
                call.UserName = personName.Text;
                call.UserVehicleInformation = vehicleInfo.Text;
                call.ReasonForCall = citationReason.SelectedItem.ToString();
                call.DateAndTime = System.DateTime.Now.ToString();

                await firebaseHelper.AddTowCallToTowHistory(call);

                //CLEAR PAGE
                searchLisencePlate.Text = "";
                vehicleInfo.Text = "";
                personName.Text = "";
                vinNumber.Text = "";
                citationReason.SelectedIndex = -1;

                Console.WriteLine("CONFIRMATION THAT CALL WAS ADDED TO DB");
            }

        }

        public async void searchLisencePlate_SearchButtonPressed(object sender, EventArgs e)
        {
            if (!IsLicenseValid())
            {
                await DisplayAlert("Error", "Required Field Incorrect or Missing", "Ok");
                return;
            }

            var person = await firebaseHelper.GetUserByLisencePlate(searchLisencePlate.Text);
            if (person != null)
            {
                personName.Text = person.FirstName + " " + person.LastName;
                vinNumber.Text = person.LicenseNumber;
                vehicleInfo.Text = person.CarYear + " " + person.CarMake + " " + person.CarModel;
            }
            else
            {
                await DisplayAlert("Error", "No Person Available", "Ok");
            }
        }

        private bool IsLicenseValid() => IsLicenseLengthValid() && !string.IsNullOrWhiteSpace(searchLisencePlate.Text);

        private bool IsLicenseLengthValid() => searchLisencePlate.Text.Length >= 2 && searchLisencePlate.Text.Length <= 7;
    }
}