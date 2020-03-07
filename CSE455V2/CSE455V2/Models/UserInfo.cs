using System;
using System.Collections.Generic;
using System.Text;

namespace CSE455V2.Models
{
    public enum AccountStatus
    {
        unlcoked, locked
    }
    public enum AccountType
    {
        student = 0, 
        faculty = 1, 
        security = 2
    }
    public class Users
    {

        private AccountStatus status;
        //private AccountType accuntType = AccountType.student;
        public string Email { get; set; }
        public string Password { get; set; }
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarYear { get; set; }
        public string CarColor { get; set; }
        public string LicenseNumber { get; set; }
        public int NumberOfCitations { get; set; }
        public AccountStatus SetAccountStatus
        {
            get
            {
                return status;
            }
            set 
            {
                    status = value;
            }
        }
        public AccountType SetAccountType { get; set; }
    }
}
