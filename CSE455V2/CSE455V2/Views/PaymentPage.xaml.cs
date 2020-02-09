using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSE455V2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage : ContentPage
    {
        public string User_adder = "Name"; // User Data
        public string card_holder = "Random Name";  // User Data
        public string address1 = "1234 Street Ave"; // User Data
        public string address2 = "City, CA 12345";  // User Data
        public string last_four = "0000";   // User Data
        public string card_info;
        public PaymentPage()
        {
            InitializeComponent();
            card_info = "****" + last_four;

            personName.Text = card_holder;             
            street.Text = address1;
            city_zip.Text = address2;
            card_name.Text = card_holder;
            numbers.Text = card_info;

        }

        void EditPaymentMethod(object sender, EventArgs args)
        {
            Navigation.PushAsync(new PaymentInformationInput());
        }

        async void DeletePaymentInfo(object sender, EventArgs args)
        {
            bool answer = await DisplayAlert("Delete Payment Information", "Are you sure you want to delete this information?", "Yes", "No");

            if(answer == true)
            {
                //Delete current UserData on Billing and payment, otherwise output "no Info exist"
            }
        }

        /*async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Email Info", "Are you sure you want to change the email associated with account?", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
        }*/
    }
}