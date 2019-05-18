using FlightsReservationApp.Models;
using FlightsReservationApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository userRepository)
        {
            this._repo = userRepository;
        }

        public async Task RegisterAsync(User user)
        {
            Console.WriteLine("Inside Service");
            await _repo.RegisterAsync(user);
            
        }
    }
}
