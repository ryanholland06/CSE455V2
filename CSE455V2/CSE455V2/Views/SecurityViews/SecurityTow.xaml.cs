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