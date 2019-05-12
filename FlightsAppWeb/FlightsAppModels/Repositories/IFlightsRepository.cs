using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightsApp.Models.Repositories
{
    public interface IFlightsRepository
    {
        Task<List<Flight>> GetAllFlightsAsync();
    }
}