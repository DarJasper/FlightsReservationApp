using System.Threading.Tasks;

namespace FlightsReservationApp.Repositories
{
    public interface ICitiesRepository
    {
        Task<string> GetAirportImage(string cityName);
    }
}