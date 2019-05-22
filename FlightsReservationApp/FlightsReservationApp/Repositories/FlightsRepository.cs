using FlightsReservationApp.Models;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Repositories
{
    public class FlightsRepository : IFlightsRepository
    {
        List<Flights> ListOfFlights = new List<Flights>();
        string url = "https://apismartappbackend.azurewebsites.net/api/Flights";

        public async Task<List<Flights>> GetFlights()
        {
            if (!ListOfFlights.Any())
                ListOfFlights = await url.GetJsonAsync<List<Flights>>();

            return ListOfFlights;
        }
    }
}
