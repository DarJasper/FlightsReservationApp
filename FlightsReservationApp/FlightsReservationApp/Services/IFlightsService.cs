using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsReservationApp.Models;

namespace FlightsReservationApp.Services
{
    public interface IFlightsService
    {
        Task<List<Flights>> GetFlightsTo(Airports airport);
    }
}