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
                }
            }
            catch
            {

            }
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    ParkingLotInfo parkingLot = new ParkingLotInfo()
        //    {
        //        ParkingLotName = "Lot J",
        //        totalCapacity = 100,
        //        currentCount = 0
        //    };
        //    var LotInfo = await FirebaseHelper.AddParkingInfo(parkingLot);
        //}
    }
}
