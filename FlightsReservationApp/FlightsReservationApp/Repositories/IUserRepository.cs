using System.Threading.Tasks;
using FlightsReservationApp.Models;

namespace FlightsReservationApp.Repositories
{
    public interface IUserRepository
    {
        Task<bool> RegisterAsync(User user);


        Task<bool> LoginAsync(User user);

        Task<Order> GetOrderForm(string email);
    }
}