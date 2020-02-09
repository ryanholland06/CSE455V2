using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CSE455V2.Models;

namespace CSE455V2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Menu, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Park_Car:
                        MenuPages.Add(id, new NavigationPage(new ParkCarPage()));
                        break;
                    case (int)MenuItemType.Map_View:
                        MenuPages.Add(id, new NavigationPage(new MapViewPage()));
                        break;
                    case (int)MenuItemType.List_View:
                        MenuPages.Add(id, new NavigationPage(new ListViewPage()));
                        break;
                    case (int)MenuItemType.User_Settings:
                        MenuPages.Add(id, new NavigationPage(new UserSettingsPage()));
                        break;
                    case (int)MenuItemType.Community_Post:
                        MenuPages.Add(id, new NavigationPage(new CommunityPostingPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}