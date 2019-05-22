using FlightsReservationApp.Models;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        //Url doesn't follow convention for these
        List<string> troubleCities = new List<string>(new string[] { "New York City", "Washington, D.C.", "Abu Dhabi"});

        public async Task<string> GetAirportImage(string cityName)
        {

            Console.WriteLine("-------3---------");
            if (troubleCities.Contains(cityName) != true)
            {
                Console.WriteLine(cityName.ToLower().Replace(" ", "-"));
                string url = "https://api.teleport.org/api/urban_areas/slug:" + cityName.ToLower().Replace(" ", "-") +"/images";
                var fetchedObject = await url.GetJsonAsync<City>();
                return fetchedObject.Photos[0].Image.Mobile;
            } else if (cityName == "New York City") {
                string url = "https://api.teleport.org/api/urban_areas/slug:new-york/images";
                var fetchedObject = await url.GetJsonAsync<City>();
                return fetchedObject.Photos[0].Image.Mobile;
            }
            else if (cityName == "Washington, D.C.")
            {
                string url = "https://api.teleport.org/api/urban_areas/slug:washington-dc/images";
                var fetchedObject = await url.GetJsonAsync<City>();
                return fetchedObject.Photos[0].Image.Mobile;

            }
            else
            {
                Console.WriteLine("You fd up");
                return "https://mobilehd.blob.core.windows.net/main/2017/02/abu-dhabi-city-skyscrapers.jpg";
            }
        }
    }
}
