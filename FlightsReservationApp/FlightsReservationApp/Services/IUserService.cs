using FlightsReservationApp.Models;
using System.Threading.Tasks;

namespace FlightsReservationApp.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(User _user);
        Task<bool> Login(User user);
    }
}