using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSE455V2.Views.SecurityViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecurityTow : ContentPage
    {
        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        public SecurityTow()
        {
            InitializeComponent();
        }

        public void CallForATowBtnClicked(object sender, EventArgs e)
        {
            PhoneDialer.Open("9999999999");
        }
    }
}