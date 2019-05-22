using FlightsReservationApp.Models;
using FlightsReservationApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Services
{
    public class FlightsService : IFlightsService
    {
        private readonly IFlightsRepository _repo;

        public FlightsService(IFlightsRepository repo)
        {
            this._repo = repo;
        }

        public async Task<List<Flights>> GetFlightsTo(Airports airport)
        {
            var allFlights = await _repo.GetFlights();
            List<Flights> flightsTo = new List<Flights>();
            foreach(var f in allFlights)
            {
                if (f.ArrivalAirport.Name == airport.Name)
                    flightsTo.Add(f);

                Console.WriteLine(f.FlightNumber);
            }
            return flightsTo;
        }
        
    }
}
