using System;
using System.Collections.Generic;
using System.Text;

namespace CSE455V2.Models
{
    public class CallHistoryToTowingCompany
    {
        public string EnforcerName { get; set; }
        public string EnforcerEmail { get; set; }
        public string EnforcerId { get; set; }
        public string UserName { get; set; }
        public string UserVehicleInformation { get; set; }
        public string ReasonForCall { get; set; }
        public string DateAndTime { get; set; }
    }
}
