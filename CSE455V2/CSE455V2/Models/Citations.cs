using System;
using System.Collections.Generic;
using System.Text;

namespace CSE455V2.Models
{
    public class Citations
    {
        //VARIABLES
        private int fineAmount = 50;

        private long citationId = Global.counter;

        private bool paidStatus = false;
        public string StudentId { get; set; }

        public string Name { get; set; }

        public string VehicleInfo { get; set; }

        public string LisencePlate { get; set; }

        public long CitationId { get { return citationId; } set { citationId = value; } }
        public string ReasonForCitation { get; set; }

        public int FineAmount { get { return fineAmount; } set { fineAmount = value; } }

        public bool PaidStatus { get { return paidStatus; } set { paidStatus = value; } }


    }
}
