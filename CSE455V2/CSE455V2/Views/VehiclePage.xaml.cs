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
    public partial class VehiclePage : ContentPage
    {
        public string CarInfo = "A1B234C";
        public VehiclePage()
        {
            InitializeComponent();
            LicensePlate.Text = CarInfo;
        }

        async void EditLicensePlate(object sender, EventArgs args)
        {
            string result = await DisplayPromptAsync("Edit Vehical Information", "Please enter new License Plate Information?");
        }
        async void DeleteLicensePlate(object sender, EventArgs args)
        {
            bool answer = await DisplayAlert("Delete Vehical Info", "Are you sure you want to delete this information?", "Yes", "No");

            if (answer == true)
            {
                //Delete current UserData, otherwise output "no Info exist"
            }
        }
    }
}