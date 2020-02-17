using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

using Xamarin.Forms.Xaml;

namespace CSE455V2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapViewPage : ContentPage
    {
        public MapViewPage()
        {
            InitializeComponent();

            Position position = new Position(34.182821, -117.323526);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);

            Map map = new Map(mapSpan)     // default can just be: Map map = new Map();
            {
                MapType = MapType.Street    // can change between views
            };

            Content = map;
        }
    }
}