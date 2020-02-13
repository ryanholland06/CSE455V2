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
        public static async Task<bool> UpdateUser(string email, string password)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new Users() { Email = email, Password = password });
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
    public static async Task<bool> AddPaymentInfo( string cardNo, string cardHolderName, string expDate)
        {
            try
            {
                await firebase
                  .Child("Payment")
                  .PostAsync(new PaymentModel() {  cardNo = cardNo, cardHolderName = cardHolderName, expDate = expDate });
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}
