using CSE455V2.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE455V2.Services
{
    //Methods for Database 
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://spotlot-e32bf.firebaseio.com/");
        #region 
        public async Task<List<UserInfo>> GetAllPersons()
        {

            return (await firebase
              .Child("UserInfo")
              .OnceAsync<UserInfo>()).Select(item => new UserInfo
              {
                  Name = item.Object.Name,
                  StudentId = item.Object.StudentId
              }).ToList();
        }

        public async Task AddPerson(int personId, string name)
        {

            await firebase
              .Child("UserInfo")
              .PostAsync(new UserInfo() { StudentId = personId, Name = name });
        }
       

        public async Task<UserInfo> GetPerson(int studentId)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("UserInfo")
              .OnceAsync<UserInfo>();
            return allPersons.Where(a => a.StudentId == studentId).FirstOrDefault();
        }

        public async Task UpdatePerson(int studentId, string name)
        {
            var toUpdatePerson = (await firebase
              .Child("UserInfo")
              .OnceAsync<UserInfo>()).Where(a => a.Object.StudentId == studentId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new UserInfo() { StudentId = studentId, Name = name });
        }

        public async Task DeletePerson(int studentId)
        {
            var toDeletePerson = (await firebase
              .Child("UserInfo")
              .OnceAsync<UserInfo>()).Where(a => a.Object.StudentId == studentId).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }
        #endregion
        #region PaymentDataMethods
        public async Task AddPayment(int studentId, string name)
        {
            await firebase
              .Child("Payment")
              .PostAsync(new PaymentModel() { studentID = studentId, cardNo = name });
        }
        #endregion
    }
}
