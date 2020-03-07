using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace CSE455V2.Views.SecurityViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecurityAlerts : ContentPage
    {
        public SecurityAlerts()
        {
            InitializeComponent();
        }

        public async void sendBtn_Clicked(object sender, EventArgs e)
        {
            await Email.ComposeAsync(subject.Text, body.Text, email.Text);
        }
    }
}