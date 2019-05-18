using FlightsReservationApp.Models;
using FlightsReservationApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Services
{
    public class FlightsService
    {
        private readonly IFlightsRepository _repo;

        public FlightsService(IFlightsRepository repo)
        {
            this._repo = repo;
        }

        public Task<List<Flights>> GetAllFlights()
        {
            return _repo.GetAllFlightsAsync();
        }
    }
}
