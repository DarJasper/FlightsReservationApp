using FlightsReservationApp.Models;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Repositories
{
    public class FlightsRepository : IFlightsRepository
    {
        public string url = "https://localhost:44387/api";

        public async Task<List<Flights>> GetAllFlightsAsync()
        {
            try
            {
                string endpoint = url + "Flights";
                
                var result = await endpoint.GetJsonAsync<List<Flights>>();

                Debug.Write(result[0].DepartureAirport.City);
                return result;
            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
