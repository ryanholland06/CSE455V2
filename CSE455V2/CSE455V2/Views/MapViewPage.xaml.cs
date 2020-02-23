using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CSE455V2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapViewPage : ContentPage
    {
        Position position = new Position(34.182821, -117.323526);
        MapSpan mapSpan;
        Map map;
        public MapViewPage()
        {
            InitializeComponent();

            mapSpan = new MapSpan(position, 0.01, 0.01);

            map = new Map(mapSpan)     // default can just be: Map map = new Map();
            {
                MapType = MapType.Street,   // can change between views
                HasScrollEnabled = false
                //HasZoomEnabled = false
            };

            double zoomLevel = 0.5;
            double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));
            if (map.VisibleRegion != null)
            {
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongDegrees, latlongDegrees));
            }

            Content = map;

            //map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));
            Debug.WriteLine("$$$$$$$$The center is: " + mapSpan.Radius.Meters + "  $$$$$");
        }
    }
}