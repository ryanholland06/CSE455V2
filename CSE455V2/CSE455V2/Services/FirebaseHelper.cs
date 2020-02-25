﻿using CSE455V2.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE455V2.Services
{
    //Methods for Database 
    public class FirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://spotlot-e32bf.firebaseio.com/");

        #region Users
        //Read All
        public static async Task<List<Users>> GetAllUser()
        {
            try
            {
                var userlist = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Select(item =>
                new Users
                {
                    Email = item.Object.Email,
                    Password = item.Object.Password,
                    StudentID = item.Object.StudentID,
                    FirstName = item.Object.FirstName,
                    LastName = item.Object.LastName,
                    CarMake = item.Object.CarMake,
                    CarModel = item.Object.CarModel,
                    CarYear = item.Object.CarYear,
                    CarColor = item.Object.CarColor,
                    LicenseNumber = item.Object.LicenseNumber
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read 
        public static async Task<Users> GetUser(string email)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebase
                .Child("Users")
                .OnceAsync<Users>();
                return allUsers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Inser a user
        public static async Task<bool> AddUser(string email, string password, string studentid,
                                                string firstname, string lastname, string carmake,
                                                string carmodel, string caryear, string carcolor,
                                                string licensenumber)
        {
            try
            {


                await firebase
                .Child("Users")
                .PostAsync(new Users()
                {
                    Email = email,
                    Password = password,
                    StudentID = studentid,
                    FirstName = firstname,
                    LastName = lastname,
                    CarMake = carmake,
                    CarModel = carmodel,
                    CarYear = caryear,
                    CarColor = carcolor,
                    LicenseNumber = licensenumber
                });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update 
        public static async Task<bool> UpdateUser(string email, string password, string studentid,
                                                string firstname, string lastname, string carmake,
                                                string carmodel, string caryear, string carcolor,
                                                string licensenumber)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new Users() {
                    Email = email,
                    Password = password,
                    StudentID = studentid,
                    FirstName = firstname,
                    LastName = lastname,
                    CarMake = carmake,
                    CarModel = carmodel,
                    CarYear = caryear,
                    CarColor = carcolor,
                    LicenseNumber = licensenumber
                });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
        public static async Task<bool> UpdateUser(Users userInfo)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == userInfo.Email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(userInfo);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }


        //Delete User
        public static async Task<bool> DeleteUser(string email)
        {
            try
            {


                var toDeletePerson = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

#endregion
    #region PaymentDataMethods
    public static async Task<bool> AddPaymentInfo( string userName, string cardNo, string cardHolderName, string expDate, string securityCode, string billingName, string streetAddr, string City, string State, string zipCode)
        {
            try
            {
                await firebase
                  .Child("Payment")
                  .PostAsync(new PaymentModel() { userName = userName, cardNo = cardNo, cardHolderName = cardHolderName, expDate = expDate, securityCode = securityCode, NameBilling = billingName, streetAdressBilling = streetAddr, billingCity = City, billingState = State, billingZipCode = zipCode });
                return true;
            }
            catch { return false; }
        }

        public static async Task<PaymentModel> GetUserPaymentInfo(string email)
        {
            try
            {
                var allUsers = await GetAllUsersPaymentInfo();
                await firebase
                .Child("Payment")
                .OnceAsync<PaymentModel>();
                return allUsers.Where(a => a.userName == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public static async Task<List<PaymentModel>> GetAllUsersPaymentInfo()
        {
            try
            {
                var userlist = (await firebase
                .Child("Payment")
                .OnceAsync<PaymentModel>()).Select(item =>
                new PaymentModel
                {
                    userName = item.Object.userName,
                    cardNo = item.Object.cardNo,
                    cardHolderName = item.Object.cardHolderName,
                    expDate = item.Object.expDate,
                    securityCode = item.Object.securityCode,
                    NameBilling = item.Object.NameBilling,
                    streetAdressBilling = item.Object.streetAdressBilling,
                    billingZipCode= item.Object.billingZipCode,
                    billingState= item.Object.billingState,
                    billingCity  = item.Object.billingCity
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public static async Task<bool> DeleteUserPaymentInfo(string email)
        {
            try
            {


                var toDeletePayment = (await firebase
                .Child("Payment")
                .OnceAsync<PaymentModel>()).Where(a => a.Object.userName == email).FirstOrDefault();
                await firebase.Child("Payment").Child(toDeletePayment.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
        public static async Task<bool> UpdatePayment(string email, string cardno, string cardholdername, string expdate, string  securitycode, string namebilling, string streetaddr, string zip, string state, string city)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Payment")
                .OnceAsync<PaymentModel>()).Where(a => a.Object.userName == email).FirstOrDefault();
                await firebase
                .Child("Payment")
                .Child(toUpdateUser.Key)
                .PutAsync(new PaymentModel() {
                    userName = email,
                    cardNo = cardno,
                    cardHolderName = cardholdername,
                    expDate = expdate,
                    securityCode = securitycode,
                    NameBilling = namebilling,
                    streetAdressBilling = streetaddr,
                    billingZipCode = zip,
                    billingState = state,
                    billingCity = city});
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
        #endregion
        #region Citation
        public static async Task<bool> AddCitationInfo(string userName, string cardNo, string cardHolderName, string expDate, string securityCode, string billingName, string streetAddr, string City, string State, string zipCode)
        {
            try
            {
                await firebase
                  .Child("Citation")
                  .PostAsync(new PaymentModel() { userName = userName, cardNo = cardNo, cardHolderName = cardHolderName, expDate = expDate, securityCode = securityCode, NameBilling = billingName, streetAdressBilling = streetAddr, billingCity = City, billingState = State, billingZipCode = zipCode });
                return true;
            }
            catch { return false; }
        }
        #endregion
        #region ParkingLotInfo
        public static async Task<bool> AddParkingInfo(ParkingLotInfo parkInfo)
        {
            try
            {
                await firebase
                  .Child("ParkingLotInfo")
                  .PostAsync(new ParkingLotInfo() { ParkingLotName = parkInfo.ParkingLotName, currentCount = parkInfo.currentCount, totalCapacity = parkInfo.totalCapacity });
                return true;
            }
            catch { return false; }
        }
        #endregion

    }
}
