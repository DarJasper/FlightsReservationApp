using FlightsReservationApp.Models;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task RegisterAsync(User user)
        {
            var url = "https://postman-echo.com/post";
            var uri = "https://localhost:44387/api/Flights";

            //var result = await url.PostJsonAsync(user).ReceiveString();
            var result = await uri.GetJsonAsync<List<Flights>>();
            Console.WriteLine(result);
        }
    }
}
