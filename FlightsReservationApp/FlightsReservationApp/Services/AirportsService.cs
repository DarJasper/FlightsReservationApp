using FlightsReservationApp.Models;
using FlightsReservationApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Services
{
    public class AirportsService : IAirportsService
    {
        private readonly IAirportsRepository _repo;

        public AirportsService(IAirportsRepository repo)
        {
            this._repo = repo;
        }

        public List<Airports> GetAllAirports()
        {
            List<Airports> AllAirports = Task.Run(() => _repo.GetAirports()).Result;
            List<Airports> AirportsNoBRU = new List<Airports>();
            foreach (var airport in AllAirports)
            {
                if (airport.Name != "BRU")
                    AirportsNoBRU.Add(airport);
            }
            return AirportsNoBRU;
        }
    }
}
