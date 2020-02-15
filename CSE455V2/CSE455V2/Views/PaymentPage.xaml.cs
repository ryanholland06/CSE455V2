using CSE455V2.Models;
using CSE455V2.Services;
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
        public string User_adder = ""; // User Data
        public string card_holder = "";  // User Data
        public string name = "";  // User Data
        public string address1 = ""; // User Data
        public string address2 = "";  // User Data
        public string last_four = "";   // User Data
        public string card_info;

        public PaymentPage()
        {
            InitializeComponent();
            card_info = last_four;
            LoadPaymentInfo(App.UserName);
            personName.Text = name;             
            street.Text = address1;
            city_zip.Text = address2;
            card_name.Text = card_holder;
            numbers.Text = card_info;

        }
        public async void LoadPaymentInfo(string email)
        {
            var paymentInfo = await FirebaseHelper.GetUserPaymentInfo(email);
            if(paymentInfo != null)
            {
                name = paymentInfo.NameBilling;
                card_holder = paymentInfo.cardHolderName;
                address1 = paymentInfo.streetAdressBilling;
                address2 = $"{paymentInfo.billingCity}, {paymentInfo.billingState}, {paymentInfo.billingZipCode}";
                card_info = GetLastDigits(paymentInfo.cardNo, 4);

                personName.Text = name;
                street.Text = address1;
                city_zip.Text = address2;
                card_name.Text = card_holder;
                if(card_info != "")
                numbers.Text = "****" + card_info;
            }
        }
        public string GetLastDigits(string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
        void EditPaymentMethod(object sender, EventArgs args)
        {
            Navigation.PushAsync(new PaymentInformationInput());
        }
        public async void UserHadPaymentInfo()
        {
            bool deleteInfo = await FirebaseHelper.DeleteUserPaymentInfo(App.UserName);
            if(!deleteInfo)
                await App.Current.MainPage.DisplayAlert("", "No Payment Info to Delete", "OK");
            else
            {
                await App.Current.MainPage.DisplayAlert("", "Deleted Payment Info", "OK");
                card_info = "";
                personName.Text = "";
                street.Text = "";
                city_zip.Text = "";
                card_name.Text = "";
                numbers.Text = "";
            }
        }
        public async void DeletePaymentInfo()
        {
            await FirebaseHelper.DeleteUserPaymentInfo(App.UserName);
        }
        async void DeletePaymentInfo(object sender, EventArgs args)
        {
            bool answer = await DisplayAlert("Delete Payment Information", "Are you sure you want to delete this information?", "Yes", "No");

            if(answer == true)
            {
                UserHadPaymentInfo();
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