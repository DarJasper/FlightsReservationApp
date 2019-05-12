using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightsApp.Models.Repositories
{
    public interface IFlightRepository
    {
        Task<List<Flight>> TestFlightsAsync();

        Task<List<Flight>> GetAllFlightsAsync();
        List<Flight> GetAllFlights();

        
    }
}