using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace FIrebaseTest2
{
    public class FirebaseHelper
    {

        readonly FirebaseClient firebase = new FirebaseClient("https://securityguardspotlottest.firebaseio.com/");

        private readonly string ChildName = "Persons";
        public async Task<List<Person>> GetAllPersons()
        {
            return (await firebase
                .Child(ChildName)
                .OnceAsync<Person>()).Select(item => new Person
                {
                    Name = item.Object.Name,
                    PersonId = item.Object.PersonId,
                    VinNum = item.Object.VinNum
                }).ToList();
        }

        public async Task AddPerson(int personId, string name, long vinNum, string vehicle)
        {
            await firebase
                .Child(ChildName)
                .PostAsync(new Person() { PersonId=personId, Name = name, VinNum = vinNum, VehicleInformation = vehicle});
        }

        public async Task<Person> GetPerson(long vinNum)
        {
            var allPersons = await GetAllPersons();
            await firebase
                .Child(ChildName)
                .OnceAsync<Person>();
            return allPersons.FirstOrDefault(a => a.VinNum == vinNum);
        }

        public async Task AddCitation(string vehInfo, long vin, int userId, string name, int fine, bool paidSt)
        {
            await firebase
                .Child("Citations")
                .PostAsync(new Citation() {Name = name, 
                                           VehicleInfo = vehInfo, 
                                           VinNumber = vin, 
                                           UserId = userId, 
                                           FineAmount = fine,
                                           PaidStatus = paidSt });
        }



    }
}
