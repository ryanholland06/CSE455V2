using System;
using System.Collections.Generic;
using System.Text;

namespace CSE455V2.Models
{
    public class ParkingLotInfo
    {
        public string ParkingLotName { get; set; }
        public int totalCapacity { get; set; }
        public int currentCount { get; set; }
    }
}
