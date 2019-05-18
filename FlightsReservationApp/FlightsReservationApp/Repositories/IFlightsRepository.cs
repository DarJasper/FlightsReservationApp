using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsReservationApp.Models;

namespace FlightsReservationApp.Repositories
{
    public interface IFlightsRepository
    {
        Task<List<Flights>> GetAllFlightsAsync();
    }
}