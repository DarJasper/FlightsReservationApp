using FlightsReservationApp.Models;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Repositories
{
    public class AirportsRepository : IAirportsRepository
    {
        List<Airports> ListOfAirports = new List<Airports>();
        string url = "https://apismartappbackend.azurewebsites.net/api/Airports";

        public async Task<List<Airports>> GetAirports()
        {
            if (!ListOfAirports.Any())
                ListOfAirports = await url.GetJsonAsync<List<Airports>>();

            return ListOfAirports;
        }
    }
}
