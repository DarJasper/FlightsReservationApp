using FlightsReservationApp.Models;
using System.Threading.Tasks;

namespace FlightsReservationApp.Services
{
    public interface IUserService
    {
        Task RegisterAsync(User _user);
    }
}