using System;
using System.Collections.Generic;
using System.Text;

namespace CSE455V2.Models
{
    public enum MenuItemType
    {
        Menu,
        Park_Car,
        Map_View,
        List_View,
        User_Settings,
        Community_Post
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
