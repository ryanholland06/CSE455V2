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
    public partial class LoginInfoPage : ContentPage
    {
        public string Uemail = App.UserName;
        public string pass = App.Password;        // replace with userData
        public LoginInfoPage()
        {
            InitializeComponent();
            userEmail.Text = Uemail;
        }

        async void ChangePassword(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Change Password", "Enter current password to continue:");

            if (result == pass)
            {
                string result2 = await DisplayPromptAsync("Enter New Password", "Exiting before submiting new password will not remove current password.");
                // have another pop up where they enter the correct pass, then if statemant
                pass = result2;
                userPassword.Text = pass;
                App.Password = pass;
                var user = await FirebaseHelper.GetUser(App.UserName);
                user.Password = pass;
                FirebaseHelper.UpdateUser(user);
            }
            else
            {
                await DisplayAlert("Error", "Incorrect Passowrd", "OK");
            }
        }

    }
}