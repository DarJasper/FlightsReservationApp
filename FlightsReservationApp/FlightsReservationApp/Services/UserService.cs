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

        public async Task<bool> RegisterAsync(User user)
        {
            return await _repo.RegisterAsync(user);
            
        }

        public async Task<bool> Login(User user)
        {
            return await _repo.LoginAsync(user);
        }
    }
}
