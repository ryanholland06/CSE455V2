using CSE455V2.Services;
using CSE455V2.ViewModels;
using Plugin.Toasts;
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
    public partial class PaymentInformationInput : ContentPage
    {
        public PaymentInformationVM paymentVM;
        public PaymentInformationInput()
        {
            InitializeComponent();
                paymentVM = new PaymentInformationVM();
                BindingContext = paymentVM;
        }
        private async void  Submitbtn_Clicked(object sender, EventArgs e)
        {
            DateTime temp;
            int cardnoTemp;
            int securityCodetemp;
            int zipCodeTemp;
            if(paymentVM.CardNo == null)
            {
                await App.Current.MainPage.DisplayAlert("", "Card number cannot be empty", "OK");

            }
            else if(paymentVM.CardholderName == null)
            {
                await App.Current.MainPage.DisplayAlert("", "Card holder name can not be empty", "OK");
            }
            else if (paymentVM.ExpDate == null)
            {
                await App.Current.MainPage.DisplayAlert("", "Experation date cannot be empty", "OK");
            }
            else if (paymentVM.BillingName == null)
            {
                await App.Current.MainPage.DisplayAlert("", "Billing name cannot be empty", "OK");
            }
            else if (paymentVM.BillingStreetAddress == null)
            {
                await App.Current.MainPage.DisplayAlert("", "Street address cannot be empty", "OK");
            }
            else if (paymentVM.BillingCity == null)
            {
                await App.Current.MainPage.DisplayAlert("", "City cannot be empty", "OK");
            }
            else if (paymentVM.BillingState == null)
            {
                await App.Current.MainPage.DisplayAlert("", "State cannot be empty", "OK");
            }
            else if (paymentVM.BillingZipCode == null)
            {
                await App.Current.MainPage.DisplayAlert("", "Zip code cannot be empty", "OK");
            }
            //Now check for the constraints
            else if (paymentVM.CardNo.Length > 16)
            {

                await App.Current.MainPage.DisplayAlert("", "Card number invalid", "OK");

            }
            else if(!DateTime.TryParse(paymentVM.ExpDate, out temp))
            {
                await App.Current.MainPage.DisplayAlert("", "Experation Date invalid", "OK");

            }
            else if (!int.TryParse(paymentVM.CardNo, out cardnoTemp))
            {
                await App.Current.MainPage.DisplayAlert("", "Card No. not valid", "OK");

            }
            else if (!int.TryParse(paymentVM.CardNo, out securityCodetemp))
            {
                await App.Current.MainPage.DisplayAlert("", "Security code not valid", "OK");

            }
            else if (!int.TryParse(paymentVM.BillingZipCode, out zipCodeTemp) || paymentVM.BillingZipCode.Length > 5)
            {
                await App.Current.MainPage.DisplayAlert("", "Zip code is not valid", "OK");

            }
            else
            {
                await FirebaseHelper.AddPaymentInfo( paymentVM.CardNo, paymentVM.CardholderName, paymentVM.ExpDate, paymentVM.SecurityCode, paymentVM.BillingName, paymentVM.BillingStreetAddress, paymentVM.BillingCity, paymentVM.BillingState, paymentVM.BillingZipCode );
                await App.Current.MainPage.DisplayAlert("", "Payment Info Updated", "OK");
            }
        }
    }
}