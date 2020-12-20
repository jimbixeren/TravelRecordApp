using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace TravelRecordApp.Logic
{
    public class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = VenueRoot.GenerateURL(latitude, longitude);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                venues = venueRoot.response.venues as List<Venue>;
            }

            return venues;
        }
    }
}










//namespace TravelRecordApp.Logic
//{
//    public class VenueLogic
//    {
//        public async static  Task<List<Venue>> GetVenues(double latitude, double longitude)
//        {
//            List<Venue> venues = new List<Venue>();

//            var url = Venue.GenerateURL(latitude, longitude);




//            using (HttpClient client = new HttpClient())
//            {
//                var response = await client.GetAsync(url);
//                var json = await response.Content.ReadAsStringAsync();

//            }

//                return venues;
//        }
//    }
//}
