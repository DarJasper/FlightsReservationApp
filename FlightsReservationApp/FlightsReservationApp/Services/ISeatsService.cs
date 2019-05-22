using FlightsReservationApp.Models;
using System.Threading.Tasks;

namespace FlightsReservationApp.Services
{
    public interface ISeatsService
    {
        Flights GetSeats(Flights flight);
        Task<bool> ReserveSelectedSeat();
    }
}