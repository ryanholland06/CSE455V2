using CSE455V2.Models;
using CSE455V2.Services;
using ParkingApp.Services;
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
    public partial class ParkCarPage : ContentPage
    {
        public ParkCarPage()
        {
            InitializeComponent();
        }

        private async void Scan_Clicked(object sender, EventArgs e)
        {

            try
            {
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    string test = result;
                    var alreadyScanned = await FirebaseHelper.GetParkRecord(result.Substring(0, 1), result.Substring(0, result.Length));

                    var record = await FirebaseHelper.GetParkRecord(App.UserName);
                    if (record == null && alreadyScanned == null)
                    {
                        ParkedInfo parkingSlot = new ParkedInfo()
                        {
                            parkingLotName = result.Substring(0, 1),
                            parkinglotNum = result.Substring(0, result.Length),
                            username = App.UserName,
                            TimeEntered = DateTime.Now
                        };
                        var parkingLot = await FirebaseHelper.GetParkingLot(result.Substring(0, 1));
                        if (parkingLot != null)
                        {
                            parkingLot.currentCount++;
                            await FirebaseHelper.UpdateParkingLotInfo(parkingLot);
                        }

                        await FirebaseHelper.AddParkedInfo(parkingSlot);
                        await App.Current.MainPage.DisplayAlert("", "Car is now Parked!", "OK");
                    }
                    else
                    {
                        if(result != null)
                        {
                            var parkingLot = await FirebaseHelper.GetParkingLot(result.Substring(0, 1));
                            if (parkingLot != null)
                            {
                                parkingLot.currentCount--;
                                await FirebaseHelper.UpdateParkingLotInfo(parkingLot);
                            }
                            await FirebaseHelper.DeleteParkedRecord(App.UserName);
                            await App.Current.MainPage.DisplayAlert("", "Car is now Unparked!", "OK");

                        }
                        else 
                            await App.Current.MainPage.DisplayAlert("", "Lot is taken!", "OK");
                    }
                }
            }
            catch
            {

            }
        }
    }
}

