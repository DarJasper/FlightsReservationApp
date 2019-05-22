using FlightsReservationApp.Models;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Repositories
{
    public class SeatsRepository : ISeatsRepository
    {
        public async Task<Flights> GetSeats(Guid flightid)
        {
            string url = "https://apismartappbackend.azurewebsites.net/api/Seats/" + flightid;
            return await url.GetJsonAsync<Flights>();
        }

        public async Task<bool> OrderSeat(Order order)
        {
            try
            {
                var url = "https://apismartappbackend.azurewebsites.net/api/Seats/Reserve";

                var result = await url.PostJsonAsync(order);
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
                // ex.Message contains rich details, inclulding the URL, verb, response status,
                // and request and response bodies (if available)
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
