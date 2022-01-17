using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinFormsMapsWithFirebase.Helpers;

namespace XamarinFormsMapsWithFirebase
{
    public partial class MainPage : ContentPage
    {

        FirebaseHelper fbhelper = new FirebaseHelper();

        public MainPage()
        {
            InitializeComponent();

            // Add a Point of Interest - example: sogo, causeway bay

            //Pin pin = new Pin
            //{
            //    Label = "Sogo HK",
            //    Address = "Hennessy Road, Causeway Bay",
            //    Type = PinType.Place,
            //    Position = new Position(22.279800, 114.183937)
            //};
            //map.Pins.Add(pin);


        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allShops = await fbhelper.GetAllShops();
            Console.WriteLine("Retrieving Shop Info ... ");
            Console.WriteLine("Number of Shops: " + allShops.Count);
            allShops.ToList().ForEach(shop =>
            {
                Console.WriteLine("Shop Name: " + shop.ShopName);
                Console.WriteLine($"District: {shop.District}");
                Console.WriteLine($"Description: {shop.Description}");
                Console.WriteLine($"Latitude: {shop.Latitude}, Longitude: {shop.Latitude}");
                Console.WriteLine("======================================================");
                Pin pin = new Pin
                {
                    Label = shop.ShopName,
                    Address = shop.District + shop.Description,
                    Type = PinType.Place,
                    Position = new Position(Convert.ToDouble(shop.Latitude), Convert.ToDouble(shop.Longitude))
                };
                map.Pins.Add(pin);
            }
            );
        }


    }
}
