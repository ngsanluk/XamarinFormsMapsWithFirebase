using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using XamarinFormsMapsWithFirebase.Models;

namespace XamarinFormsMapsWithFirebase.Helpers
{
    public class FirebaseHelper
    {
        // PUT THE CORRECT URL OF YOUR FIREBASE REAL TIME DATABASE BELOW
        FirebaseClient firebase =
            new FirebaseClient("https://cst3580-2021-demo-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public FirebaseHelper()
        {
        }

        public async Task<List<Shop>> GetAllShops()
        {
            return (await firebase
              .Child("Shop")
              .OnceAsync<Shop>()).Select(item => new Shop
              {
                  ShopName = item.Object.ShopName,
                  District = item.Object.District,
                  Description = item.Object.Description,
                  Latitude = item.Object.Latitude,
                  Longitude = item.Object.Longitude
              }).ToList();
        }
    }
}
