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
            bool informationIsValid = true;
            if(paymentVM.CardholderName == null)
            {
                informationIsValid = false;
            }
            if(paymentVM.CardNo == null)
            {
                informationIsValid = false;

            }
            if (paymentVM.ExpDate == null)
            {
                informationIsValid = false;
            }
            if (informationIsValid)
                await FirebaseHelper.AddPaymentInfo(paymentVM.CardholderName, paymentVM.CardNo, paymentVM.ExpDate);
        }
    }
}