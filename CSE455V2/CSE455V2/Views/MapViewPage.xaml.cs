using CSE455V2.Models;
using CSE455V2.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CSE455V2.Views
{   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapViewPage : ContentPage
    {
        // Map Properties
        Position position = new Position(34.182821, -117.323526);
        CustomMap map = new CustomMap();
        // List created to gather and change info
        List<ParkingLotInfo> LotList = new List<ParkingLotInfo>();
        private List<Polygon> shapes = new List<Polygon>();
        List<CustomPin> PinList = new List<CustomPin>();
        public int LotACount =0;

        // all Lot shapes on campus
        Polygon lotL = new Polygon
        {
            StrokeWidth = 8,
            StrokeColor = Color.FromHex("#03C04A"),
            FillColor = Color.FromHex("#8803C04A"),
            Geopath =
                {
                    new Position(34.186291, -117.327119),
                    new Position(34.185522, -117.326332),
                    new Position(34.185773, -117.325967),
                    new Position(34.185904, -117.326082),
                    new Position(34.186079, -117.325865),
                    new Position(34.186458, -117.326289),
                    new Position(34.186655, -117.326045),
                    new Position(34.186910, -117.326410)
                }
        };
        Polygon lotA = new Polygon
        {
            StrokeWidth = 8,
            StrokeColor = Color.FromHex("#03C04A"),
            FillColor = Color.FromHex("#8803C04A"),
            Geopath =
                {
                    new Position(34.186495, -117.328797),
                    new Position(34.185785, -117.328000),
                    new Position(34.186302, -117.327356),
                    new Position(34.186828, -117.327976)
                }
        };
        Polygon lotB = new Polygon
        {
            StrokeWidth = 8,
            StrokeColor = Color.FromHex("#03C04A"),
            FillColor = Color.FromHex("#8803C04A"),
            Geopath =
                {
                    new Position(34.183258, -117.328517),
                    new Position(34.182861, -117.329745),
                    new Position(34.182442, -117.329528),
                    new Position(34.182389, -117.329198),
                    new Position(34.182620, -117.328216)
                }
        };
        Polygon lotK = new Polygon
        {
            StrokeWidth = 8,
            StrokeColor = Color.FromHex("#03C04A"),
            FillColor = Color.FromHex("#8803C04A"),
            Geopath =
                {
                    new Position(34.184195, -117.328776),
                    new Position(34.184148, -117.329227),
                    new Position(34.183831, -117.329017),
                    new Position(34.183665, -117.328757),
                    new Position(34.183438, -117.328291),
                    new Position(34.183806, -117.328160)
                }
        };
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
        Polygon lotE = new Polygon
        {
            StrokeWidth = 8,
            StrokeColor = Color.FromHex("#03C04A"),
            FillColor = Color.FromHex("#8803C04A"),
            Geopath =
                {
                    new Position(34.184554, -117.320294),
                    new Position(34.183789, -117.320911),
                    new Position(34.183472, -117.320176),
                    new Position(34.184189, -117.319618)
                }
        };
        Polygon lotN = new Polygon
        {
            StrokeWidth = 8,
            StrokeColor = Color.FromHex("#03C04A"),
            FillColor = Color.FromHex("#8803C04A"),
            Geopath =
                {
                    new Position(34.184839, -117.320503),
                    new Position(34.183932, -117.321190),
                    new Position(34.184271, -117.321850),
                    new Position(34.183738, -117.322287),
                    new Position(34.184286, -117.323234),
                    new Position(34.184643, -117.322952),
                    new Position(34.185178, -117.323931),
                    new Position(34.185635, -117.323606),
                    new Position(34.185586, -117.323456),
                    new Position(34.185843, -117.323204),
                    new Position(34.185426, -117.322359),
                    new Position(34.185557, -117.322230),
                    new Position(34.185071, -117.321259),
                    new Position(34.185184, -117.321146)
                }
        };
        // all pins added to list and map
        CustomPin pinL = new CustomPin
        {
            Label = "Lot F",
            Type = PinType.Place,
            Position = new Position(34.186338, -117.326572)
        };
        CustomPin pinA = new CustomPin
        {
            Label = "Lot A",
            Type = PinType.Place,
            Position = new Position(34.186307, -117.328042)
        };
        CustomPin pinB = new CustomPin
        {
            Label = "Lot B",
            Type = PinType.Place,
            Position = new Position(34.182913, -117.328776)
        };
        CustomPin pinK = new CustomPin
        {
            Label = "Lot B",
            Type = PinType.Place,
            Position = new Position(34.183821, -117.328685)
        };
        CustomPin pinC = new CustomPin
        {
            Label = "Lot C",
            Type = PinType.Place,
            Position = new Position(34.180811, -117.327492)
        };
        CustomPin pinD = new CustomPin
        {
            Label = "Lot D",
            Type = PinType.Place,
            Position = new Position(34.178944, -117.324553)
        };
        CustomPin pinF = new CustomPin
        {
            Label = "Lot F",
            Type = PinType.Place,
            Position = new Position(34.178717, -117.320145)
        };
        CustomPin pinG = new CustomPin
        {
            Label = "Lot G",
            Type = PinType.Place,
            Position = new Position(34.180183, -117.318607)
        };
        CustomPin pinH = new CustomPin
        {
            Label = "Lot H",
            Type = PinType.Place,
            Position = new Position(34.179039, -117.318124)
        };
        CustomPin pinE = new CustomPin
        {
            Label = "East Parking Structure",
            Type = PinType.Place,
            Position = new Position(34.183910, -117.320227)
        };
        CustomPin pinN = new CustomPin
        {
            Label = "Lot N",
            Type = PinType.Place,
            Position = new Position(34.184806, -117.322195),
            //Name = "this random name"         // adding this field will allow users to open Gmaps to get directions.
        };
        // Parking lot info that in the database
        ParkingLotInfo A_Lot = new ParkingLotInfo
        {
            ParkingLotName = "Lot A",
            totalCapacity = 200,
            currentCount =  0     
        };
        ParkingLotInfo B_Lot = new ParkingLotInfo
        {
            ParkingLotName = "Lot B",
            totalCapacity = 200,
            currentCount = 0
        };
        ParkingLotInfo C_Lot = new ParkingLotInfo
        {
            ParkingLotName = "Lot C",
            totalCapacity = 200,
            currentCount = 0
        };
        ParkingLotInfo D_Lot = new ParkingLotInfo
        {
            ParkingLotName = "Lot D",
            totalCapacity = 200,
            currentCount = 0
        };
        ParkingLotInfo E_Lot = new ParkingLotInfo
        {
            ParkingLotName = "East Parking Structure",
            totalCapacity = 200,
            currentCount = 0
        };
        ParkingLotInfo F_Lot = new ParkingLotInfo
        {
            ParkingLotName = "Lot F Front",
            totalCapacity = 706,
            currentCount = 0
        };
        ParkingLotInfo G_Lot = new ParkingLotInfo
        {
            ParkingLotName = "Lot G",
            totalCapacity = 605,
            currentCount = 0
        };
        ParkingLotInfo H_Lot = new ParkingLotInfo
        {
            ParkingLotName = "Lot H",
            totalCapacity = 587,
            currentCount = 0
        };
        ParkingLotInfo K_Lot = new ParkingLotInfo
        {
            ParkingLotName = "Lot B Annex",
            totalCapacity = 200,
            currentCount = 0
        };
        ParkingLotInfo L_Lot = new ParkingLotInfo
        {
            ParkingLotName = "Lot F Back",
            totalCapacity = 200,
            currentCount = 0
        };
        ParkingLotInfo N_Lot = new ParkingLotInfo
        {
            ParkingLotName = "Lot N",
            totalCapacity = 200,
            currentCount = 0
        };

        public class CustomMap : Map
        {
            public List<CustomPin> CustomPins { get; set; }
        }
        public class CustomPin : Pin
        {
            public string Name { get; set; }
            //public string Url { get; set; }
        }
        public async void LoadList()
        {
            try
            {
                LotList = await FirebaseHelper.GetAllParkingLotInfo();
                UpdateMap(shapes, LotList, PinList);
                LoadList();
            }
            catch { }
        }

        public  MapViewPage()
        {
            InitializeComponent();
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            map = new CustomMap()     // default can just be: Map map = new Map();
            {
                MapType = MapType.Street
            };
            LoadList();

            map.MoveToRegion(new MapSpan(position, 0.01, 0.01));

             AddStuffToList(shapes, LotList, map);

            Content = map;

            //UpdateMap(shapes, LotList, PinList);
           // UpdateListendless();
        }
        public void AddStuffToList(List<Polygon> shapes,List<ParkingLotInfo> LotList, CustomMap map)
        {
           
            // List of polygons
            shapes.Add(lotA);
            shapes.Add(lotB);
            shapes.Add(lotC);
            shapes.Add(lotD);
            shapes.Add(lotE);
            shapes.Add(lotF);
            shapes.Add(lotG);
            shapes.Add(lotH);
            shapes.Add(lotK);
            shapes.Add(lotL);
            shapes.Add(lotN);            
            // Pins
            map.Pins.Add(pinA);
            map.Pins.Add(pinB);
            map.Pins.Add(pinC);
            map.Pins.Add(pinD);
            map.Pins.Add(pinE);
            map.Pins.Add(pinF);
            map.Pins.Add(pinG);
            map.Pins.Add(pinH);
            map.Pins.Add(pinK);
            map.Pins.Add(pinL);
            map.Pins.Add(pinN);
            // Database values: Name, TotalCapacity, CurrentCapacity
            //LotList.Add(L_Lot);
            //LotList.Add(A_Lot);
            //LotList.Add(K_Lot);
            //LotList.Add(B_Lot);
            //LotList.Add(C_Lot);
            //LotList.Add(D_Lot);
            //LotList.Add(F_Lot);
            //LotList.Add(G_Lot);
            //LotList.Add(H_Lot);
            //LotList.Add(E_Lot);
            //LotList.Add(N_Lot);

            // Polygons being added to map
            map.MapElements.Add(lotA);
            map.MapElements.Add(lotB);
            map.MapElements.Add(lotC);
            map.MapElements.Add(lotD);
            map.MapElements.Add(lotE);
            map.MapElements.Add(lotF);
            map.MapElements.Add(lotG);
            map.MapElements.Add(lotH);
            map.MapElements.Add(lotK);
            map.MapElements.Add(lotL);
            map.MapElements.Add(lotN);
            // Adds Pins to List of Pins
            PinList.Add(pinA);
            PinList.Add(pinB);
            PinList.Add(pinC);
            PinList.Add(pinD);
            PinList.Add(pinE);
            PinList.Add(pinF);
            PinList.Add(pinG);
            PinList.Add(pinH);
            PinList.Add(pinK);
            PinList.Add(pinL);
            PinList.Add(pinN);
        }
        public void UpdateMap(List<Polygon> LotShape, List<ParkingLotInfo> LotList, List<CustomPin> pinlist)
        {
            //foreach(var Lot in LotShape)
            for (int i = 0; i < LotShape.Count; i++)
            {
                pinlist[i].Address = LotList[i].currentCount + "/" + LotList[i].totalCapacity;

                if (LotList[i].currentCount <= LotList[i].totalCapacity * 0.40)
                {
                    LotShape[i].StrokeColor = Color.FromHex("#03C04A");
                    LotShape[i].FillColor = Color.FromHex("#8803C04A");
                }
                else if (LotList[i].currentCount >= LotList[i].totalCapacity * 0.85)
                {
                    LotShape[i].StrokeColor = Color.FromHex("#e74c3c");
                    LotShape[i].FillColor = Color.FromHex("#ec7063");
                }
                else
                {
                    LotShape[i].StrokeColor = Color.FromHex("#f1c40f");
                    LotShape[i].FillColor = Color.FromHex("#f4d03f");
                }
            }
        }
    }
}