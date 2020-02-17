using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using CSE455V2.Views;
using CSE455V2.Services;
using System.Text.RegularExpressions;

namespace CSE455V2.ViewModel
{
    public class SignUpVM : INotifyPropertyChanged
    {
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        private string studentid;
        public string StudentID
        {
            get { return studentid; }
            set
            {
                studentid = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StudentID"));
            }
        }

        private string firstname;
        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        private string lastname;
        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        private string carmake;
        public string CarMake
        {
            get { return carmake; }
            set
            {
                carmake = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CarMake"));
            }
        }

        private string carmodel;
        public string CarModel
        {
            get { return carmodel; }
            set
            {
                carmodel = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CarModel"));
            }
        }

        private string caryear;
        public string CarYear
        {
            get { return caryear; }
            set
            {
                caryear = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CarYear"));
            }
        }

        private string carcolor;
        public string CarColor
        {
            get { return carcolor; }
            set
            {
                carcolor = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CarColor"));
            }
        }

        private string licensenumber;
        public string LicenseNumber
        {
            get { return licensenumber; }
            set
            {
                licensenumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LicenseNumber"));
            }
        }

        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }
        public Command SignUpCommand
        {
            get
            {
                return new Command(() =>
                {
                    var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

                    //null or empty field validation, check weather email and password is null or empty
                    if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                    {
                        App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
                    }
                    else if (!Email.Contains("@"))
                    {
                        App.Current.MainPage.DisplayAlert("", "Email Address is Invalid", "OK");
                    }
                    else if (Password.Length < 8)
                    {
                        App.Current.MainPage.DisplayAlert("", "Password is less than 8 characters", "OK");
                    }
                    else if (!Password.Any(char.IsUpper))
                    {
                        App.Current.MainPage.DisplayAlert("", "Password Must Contain at Least 1 Uppcase Letter", "OK");
                    }
                    else if (!hasSymbols.IsMatch(Password))
                    {
                        App.Current.MainPage.DisplayAlert("", "Password should contain At least one special case characters", "OK");
                    }
                    else if (Password != ConfirmPassword)
                    {
                        App.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
                    }
                    else if (string.IsNullOrEmpty(StudentID))
                    {
                        App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Student ID", "OK");
                    }
                    else if (StudentID.Length < 9)
                    {
                        App.Current.MainPage.DisplayAlert("", "Student ID is Incorrect!", "OK");
                    }
                    else
                    {
                        SignUp();
                    }

                });

            }

        }
        private async void SignUp()
        {
            //call AddUser function which we define in Firebase helper class
            var user = await FirebaseHelper.AddUser(Email, Password, StudentID, FirstName, LastName, CarMake, CarModel,
                                                    CarYear, CarColor, LicenseNumber);
            //AddUser return true if data insert successfuly 
            if (user)
            {
                await App.Current.MainPage.DisplayAlert("SignUp Success", "", "Ok");
                //Navigate to Wellcom page after successfuly SignUp
                //pass user email to welcom page
                await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            else
                await App.Current.MainPage.DisplayAlert("Error", "SignUp Fail", "OK");
        }
    }
}
