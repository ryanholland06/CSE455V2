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
        private string securityCode;
        public string SecurityCode
        {
            get { return securityCode; }
            set
            {
                securityCode = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SecurityCode"));
            }
        }
        private string billingName;
        public string BillingName
        {
            get { return billingName; }
            set
            {
                billingName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BillingName"));
            }
        }
        private string billingStreetAddress;
        public string BillingStreetAddress
        {
            get { return billingStreetAddress; }
            set
            {
                billingStreetAddress = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BillingStreetAddress"));
            }
        }
        private string billingCity;
        public string BillingCity
        {
            get { return billingCity; }
            set
            {
                billingCity = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BillingCity"));
            }
        }
        private string billingState;
        public string BillingState
        {
            get { return billingState; }
            set
            {
                billingState = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BillingState"));
            }
        }
        private string billingZipCode;
        public string BillingZipCode
        {
            get { return billingZipCode; }
            set
            {
                billingZipCode = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BillingZipCode"));
            }
        }

    }
}
