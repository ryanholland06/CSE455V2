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
        public string expDate { get; set; }
        public string securityCode { get; set; }
        public string NameBilling { get; set; }
        public string streetAdressBilling { get; set; }
        public string billingZipCode { get; set; }
        public string billingState { get; set; }
        public string billingCity { get; set; }

    }
}
