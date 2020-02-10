using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CSE455V2.ViewModel;
using CSE455V2.Services;

namespace CSE455V2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        SignUpVM signUpVM;
        public SignUpPage()
        {
            InitializeComponent();
            signUpVM = new SignUpVM();
            //    //set binding
            BindingContext = signUpVM;
        }

        async void Test2_Clicked(object sender, System.EventArgs e)
        {

            if (string.IsNullOrEmpty(signUpVM.Email) || string.IsNullOrEmpty(signUpVM.Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call AddUser function which we define in Firebase helper class
                var user = await FirebaseHelper.AddUser(signUpVM.Email, signUpVM.Password, signUpVM.StudentID, signUpVM.FirstName, signUpVM.LastName, signUpVM.CarMake, signUpVM.CarModel,
                                                        signUpVM.CarYear, signUpVM.CarColor, signUpVM.LicenseNumber);
                //AddUser return true if data insert successfuly 
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("SignUp Success", "", "Ok");
                    //Navigate to Wellcom page after successfuly SignUp
                    //pass user email to welcom page
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "SignUp Fail", "OK");
            }
        }
    }
}