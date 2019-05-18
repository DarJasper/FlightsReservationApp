using System.Threading.Tasks;
using FlightsReservationApp.Models;

namespace FlightsReservationApp.Repositories
{
    public interface IUserRepository
    {
        Task RegisterAsync(User user);
    }
}