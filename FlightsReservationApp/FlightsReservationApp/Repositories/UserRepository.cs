using FlightsReservationApp.Models;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> RegisterAsync(User user)
        {
            try
            {
                var url = "https://apismartappbackend.azurewebsites.net/api/Users/Register";

                var result = await url.PostJsonAsync(user);
                Console.WriteLine(result.ToString());
                if (result.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FlurlHttpTimeoutException)
            {
                // FlurlHttpTimeoutException derives from FlurlHttpException; catch here only
                // if you want to handle timeouts as a special case
                return false;
            }
            catch (FlurlHttpException ex)
            {
                // ex.Message contains rich details, inclulding the URL, verb, response status,
                // and request and response bodies (if available)
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> LoginAsync(User user)
        {
            try
            {
                var url = "https://apismartappbackend.azurewebsites.net/api/Users/Login";

                var result = await url.PostJsonAsync(user);
                Console.WriteLine(result.ToString());
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FlurlHttpTimeoutException)
            {
                // FlurlHttpTimeoutException derives from FlurlHttpException; catch here only
                // if you want to handle timeouts as a special case
                return false;
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex);
                // ex.Message contains rich details, inclulding the URL, verb, response status,
                // and request and response bodies (if available)
                return false;
            }
        }

        public async Task<Order> GetOrderForm(string email)
        {
            string url = "https://apismartappbackend.azurewebsites.net/api/Users/FetchForm" + email;
            return await url.GetJsonAsync<Order>();
        }
    }
}