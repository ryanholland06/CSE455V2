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

            Polygon lotC = new Polygon
            {
                StrokeWidth = 8,
                StrokeColor = Color.FromHex("#03C04A"),
                FillColor = Color.FromHex("#8803C04A"),
                Geopath =
                {
                    new Position(34.182275, -117.327918),
                    new Position(34.181519, -117.328865),
                    new Position(34.179375, -117.327221),
                    new Position(34.180391, -117.325899)
                }
            };

            Polygon lotD = new Polygon
            {
                StrokeWidth = 8,
                StrokeColor = Color.FromHex("#03C04A"),
                FillColor = Color.FromHex("#8803C04A"),
                Geopath =
                {
                    new Position(34.180105, -117.325223),
                    new Position(34.178490, -117.325837),
                    new Position(34.177722, -117.323699),
                    new Position(34.179042, -117.323146),
                    new Position(34.179093, -117.323401),
                    new Position(34.179708, -117.323307)
                }
            };

            Polygon lotE = new Polygon
            {
                StrokeWidth = 8,
                StrokeColor = Color.FromHex("#03C04A"),
                FillColor = Color.FromHex("#8803C04A"),
                Geopath =
                {
                    new Position(34.180222, -117.321648),
                    new Position(34.179137, -117.321264),
                    new Position(34.179457, -117.319872),
                    new Position(34.180575, -117.320288),
                    new Position(34.180484, -117.321527)
                }
            };

            Polygon lotF = new Polygon
            {
                StrokeWidth = 8,
                StrokeColor = Color.FromHex("#03C04A"),
                FillColor = Color.FromHex("#8803C04A"),
                Geopath =
                {
                    new Position(34.179355, -117.319829),
                    new Position(34.179033, -117.321226),
                    new Position(34.177662, -117.320708),
                    new Position(34.177915, -117.319514),
                    new Position(34.178552, -117.319734),
                    new Position(34.178678, -117.319595)
                }
            };

            Polygon lotG = new Polygon
            {
                StrokeWidth = 8,
                StrokeColor = Color.FromHex("#03C04A"),
                FillColor = Color.FromHex("#8803C04A"),
                Geopath =
                {
                    new Position(34.179628, -117.319110),
                    new Position(34.179928, -117.317844),
                    new Position(34.180827, -117.318152),
                    new Position(34.180834, -117.319523)
                }
            };

            Polygon lotH = new Polygon
            {
                StrokeWidth = 8,
                StrokeColor = Color.FromHex("#03C04A"),
                FillColor = Color.FromHex("#8803C04A"),
                Geopath =
                {
                    new Position(34.179533, -117.319089),
                    new Position(34.178330, -117.318536),
                    new Position(34.178836, -117.317479),
                    new Position(34.179810, -117.317820)
                }
            };

            map.MapElements.Add(lotC);
            map.MapElements.Add(lotD);
            map.MapElements.Add(lotE);
            map.MapElements.Add(lotF);
            map.MapElements.Add(lotG);
            map.MapElements.Add(lotH);
        }

    }
}