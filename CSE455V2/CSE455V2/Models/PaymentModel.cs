using System;
using System.Collections.Generic;
using System.Text;

namespace CSE455V2.Models
{
    public class PaymentModel
    {
        public int studentID { get; set; }
        public string cardNo { get; set; }
        public string userName { get; set; }
        public string cardHolderName { get; set; }
        public DateTime? exprationDate { get; set; }
        public int secuirtCode { get; set; }
        public string NameBilling { get; set; }
        public string streetAdressBilling { get; set; }

        public string cityStateZipCode { get; set; }

    }
}
