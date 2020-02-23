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
            //mapSpan.Radius.Meters.Equals(300);

            map = new Map(mapSpan)     // default can just be: Map map = new Map();
            {
                MapType = MapType.Street,   // can change between views
                HasScrollEnabled = false,
                HasZoomEnabled = false
            };

            Content = map;

            //map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));
            Debug.WriteLine("$$$$$$$$The center is: " + mapSpan.Radius.Meters + "  $$$$$");
        }
    }
}