using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsReservationApp.Models;

namespace FlightsReservationApp.Repositories
{
    public interface IAirportsRepository
    {
        Task<List<Airports>> GetAirports();
    }
}