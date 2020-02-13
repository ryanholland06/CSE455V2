using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CSE455V2.ViewModels
{
    public class PaymentInformationVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string userName;
        public string UserNAme
        {
            get { return userName; }
            set
            {
                userName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            }
        }
        private string cardNo;
        public string CardNo
        {
            get { return cardNo; }
            set
            {
                cardNo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CarNo"));
            }
        }
        private string cardholderName;
        public string CardholderName
        {
            get { return cardholderName; }
            set
            {
                cardholderName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CardholderName"));
            }
        }
        private string expDate;
        public string ExpDate
        {
            get { return expDate; }
            set
            {
                expDate= value;
                PropertyChanged(this, new PropertyChangedEventArgs("ExpDate"));
            }
        }
    }
}
