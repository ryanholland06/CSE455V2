using CSE455V2.Models;
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
                    LicenseNumber = item.Object.LicenseNumber,
                    SetAccountType = item.Object.SetAccountType //ADD; THIS SHOULD SPECIFY WHAT ACCOUNT TYPE THE USER IS
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<List<Citations>> GetAllCitations()
        {
            try
            {
                var citationlist = (await firebase
                .Child("Citations")
                .OnceAsync<Citations>()).Select(item =>
                new Citations
                {
                    StudentId = item.Object.StudentId,
                    Name = item.Object.Name,
                    VehicleInfo = item.Object.VehicleInfo,
                    LisencePlate = item.Object.LisencePlate,
                    NumberOfCitations = item.Object.NumberOfCitations,
                    CitationId = item.Object.CitationId,
                    ReasonForCitation = item.Object.ReasonForCitation,
                    FineAmount = item.Object.FineAmount,
                    PaidStatus = item.Object.PaidStatus
                }).ToList();
                return citationlist;
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

        public async Task<Users> GetUserByLisencePlate(string lisencePlate)
        {
            var allPersons = await GetAllUser();
            await firebase
                .Child("Users")
                .OnceAsync<Users>();
            return allPersons.FirstOrDefault(a => a.LicenseNumber == lisencePlate);
        }

        //Will retrieve all citations matching the parameter lisencePlate
        public async Task<List<Citations>> GetCitationsByLisencePlate(string lisencePlate)
        {
            var allCitations = await GetAllCitations();
            await firebase
                .Child("Citations")
                .OnceAsync<Citations>();
            var citationsFound = allCitations.Where(e => e.LisencePlate == lisencePlate).ToList();
            return citationsFound;
           
             
        }

        //Insert a user
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
                    LicenseNumber = licensenumber,
                    SetAccountType = AccountType.student //DEFAULT TO STUDENT UNLESS CHANGED THROUGH FIREBASE
                });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //ADD CITATION TO FIREBASE DB
        public async Task AddCitation(string vehInfo, string lisencePlate, string studentId, string name, string reason)
        {
            await UpdateCitationCounter();

            await firebase
                .Child("Citations")
                .PostAsync(new Citations()
                {
                    Name = name,
                    VehicleInfo = vehInfo,
                    LisencePlate = lisencePlate,
                    StudentId = studentId,
                    ReasonForCitation = reason,
                    CitationId = Global.counter
                });
        }
        //This method will make sure that no citation ids match by comparing the exisinting ids to the current counter and then incrementing the global counter
        public async Task UpdateCitationCounter()
        {
            var allCitations =  await GetAllCitations();
            await firebase
                .Child("Citations")
                .OnceAsync<Citations>();
            foreach(var citationId in allCitations)
            {
                if(citationId.CitationId == Global.counter)
                {
                    Global.counter++;
                }
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
        public static async Task<bool> UpdateParkingLotInfo(ParkingLotInfo parkInfo)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("ParkingLotInfo")
                .OnceAsync<ParkingLotInfo>()).Where(a => a.Object.ParkingLotName == parkInfo.ParkingLotName).FirstOrDefault();
                await firebase
                .Child("ParkingLotInfo")
                .Child(toUpdateUser.Key)
                .PutAsync(parkInfo);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
        public static async Task<ParkingLotInfo> GetParkingLot(string parkingLot)
        {
            try
            {
                var allUsers = await GetAllParkingLotInfo();
                await firebase
                .Child("ParkingLotInfo")
                .OnceAsync<ParkingLotInfo>();
                return allUsers.Where(a => a.ParkingLotName == parkingLot).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public static async Task<int> GetParkingLotCount(string parkingLot)
        {
            try
            {
                var allUsers = await GetAllParkingLotInfo();
                await firebase
                .Child("ParkingLotInfo")
                .OnceAsync<ParkingLotInfo>();
                return allUsers.Where(a => a.ParkingLotName == parkingLot).FirstOrDefault().currentCount;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return 0;
            }
        }
        public static async Task<List<ParkingLotInfo>> GetAllParkingLotInfo()
        {
            try
            {
                var parkingLotlist = (await firebase
                .Child("ParkingLotInfo")
                .OnceAsync<ParkingLotInfo>()).Select(item =>
                new ParkingLotInfo
                {
                    ParkingLotName = item.Object.ParkingLotName,
                    totalCapacity = item.Object.totalCapacity,
                    currentCount = item.Object.currentCount
                }).ToList();
                return parkingLotlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        #endregion
        #region parkedInfo
        public static async Task<bool> AddParkedInfo(ParkedInfo parkInfo)
        {
            try
            {
                await firebase
                  .Child("ParkedInfo")
                  .PostAsync(new ParkedInfo() {  username = parkInfo.username, parkingLotName = parkInfo.parkingLotName, parkinglotNum= parkInfo.parkinglotNum, TimeEntered = parkInfo.TimeEntered});
                return true;
            }
            catch { return false; }
        }
        public static async Task<List<ParkedInfo>> GetAllParkedInfo()
        {
            try
            {
                var parklist = (await firebase
                .Child("ParkedInfo")
                .OnceAsync<ParkedInfo>()).Select(item =>
                new ParkedInfo
                {
                    username = item.Object.username,
                    parkingLotName= item.Object.parkingLotName,
                    parkinglotNum = item.Object.parkinglotNum,
                    TimeEntered = item.Object.TimeEntered
                }).ToList();
                return parklist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public static async Task<ParkedInfo> GetParkRecord(string email)
        {
            try
            {
                var allUsers = await GetAllParkedInfo();
                await firebase
                .Child("ParkedInfo")
                .OnceAsync<ParkedInfo>();
                return allUsers.Where(a => a.username == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public static async Task<bool> DeleteParkedRecord(string email)
        {
            try
            {


                var toDeleteRecord = (await firebase
                .Child("ParkedInfo")
                .OnceAsync<ParkedInfo>()).Where(a => a.Object.username == email).FirstOrDefault();
                await firebase.Child("ParkedInfo").Child(toDeleteRecord.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        #endregion

    }
}
