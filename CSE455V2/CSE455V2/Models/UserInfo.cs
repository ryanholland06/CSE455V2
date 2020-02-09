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
        student, facaulty, security
    }
    public class UserInfo
    {

        AccountStatus status;
        AccountType accuntType;
        public int StudentId { get; set; }
        
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
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
        public AccountType SetAccountType
        {
            get
            {
                return accuntType;
            }
            set
            {
                accuntType = value;
            }
        }
    }
}
