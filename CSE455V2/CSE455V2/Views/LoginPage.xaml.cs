using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CSE455V2. ViewModel;
using CSE455V2.Services;

namespace CSE455V2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public LoginPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            loginViewModel = new LoginViewModel();
            InitializeComponent();
            BindingContext = loginViewModel;
        }

        private async void Loginbtn_Clicked(object sender, EventArgs e)
        {
            //null or empty field validation, check weather email and password is null or empty

            if (string.IsNullOrEmpty(loginViewModel.Email) || string.IsNullOrEmpty(loginViewModel.Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class
                var user = await FirebaseHelper.GetUser(loginViewModel.Email);
                //firebase return null valuse if user data not found in database
                if (user != null)
                    if (loginViewModel.Email == user.Email && loginViewModel.Password == user.Password)
                    {
                        await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                        //Navigate to Wellcom page after successfuly login
                        //pass user email to welcom page
                        await Navigation.PushAsync(new MainMenuPage());

                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }
        }
        // made these two just for now
        void Signupbtn_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }


        void Test_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainMenuPage());
        }
    }
}