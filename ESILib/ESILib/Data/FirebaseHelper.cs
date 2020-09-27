using ESILib.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESILib.Data
{
    public class FirebaseHelper
    {
        FirebaseClient firebase= new FirebaseClient("https://esilib.firebaseio.com/");
        public FirebaseHelper()
        {
        }

        public async Task<List<Book>> GetAllBooks()
        {

            try
            {
                return (await firebase
               .Child("Book")
               .OnceAsync<Book>()).Select(item => new Book
               {
                   Category = item.Object.Category,
                   BookKey = item.Key,
                   Title = item.Object.Title,
                   Author = item.Object.Author,
                   Description = item.Object.Description,
                   ISBN = item.Object.ISBN,
                   Coverurl = item.Object.Coverurl.Replace("http://", "https://"),
                   Available = item.Object.Available,
               }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error - Additional information..." + ex, ex);
            }
        }

        public async Task<List<Book>> GetLatestBooks()
        {

            try
            {
                return (await firebase
               .Child("Book").OrderByKey().LimitToFirst(10).OnceAsync<Book>()).Select(item => new Book
               {
                   Category = item.Object.Category,
                   BookKey = item.Key,
                   Title = item.Object.Title,
                   Author = item.Object.Author,
                   Description = item.Object.Description,
                   ISBN = item.Object.ISBN,
                   Coverurl = item.Object.Coverurl.Replace("http://", "https://"),
                   Available = item.Object.Available,
               }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error - Additional information..." + ex, ex);
            }
        }

        // Adding A Book To THe Firebase Database
        public async Task AddRequest(Request request)
        {
            await firebase
              .Child("Requests")
              .PostAsync(request);

        }

    }
}
