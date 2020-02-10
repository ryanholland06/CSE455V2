using CSE455V2.Services;
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
        public PaymentInformationInput()
        {
            InitializeComponent();
        }
        private async void  Submitbtn_Clicked(object sender, EventArgs e)
        {
            //var paymentInfo = await FirebaseHelper.AddPaymentInfo(cardHolderName, CardNo.Text, );
        }
    }
}