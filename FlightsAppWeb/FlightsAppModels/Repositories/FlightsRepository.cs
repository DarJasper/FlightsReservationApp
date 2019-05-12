using Microsoft.Extensions.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FlightsApp.Models.Repositories
{
    public class FlightsRepository : IFlightsRepository
    {
        private readonly string connectionString;
        public FlightsRepository(IConfiguration config)
        {
            var connectionConfig = config.GetSection("Configurations")["OtherConnection"];
            connectionString = ConfigurationExtensions.GetConnectionString(config, "DefaultConnection");
        }

        // 1) READ
        // 1-a) ALL
        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            List<Flight> lst = new List<Flight>();
            string query = "SELECT f.FlightsId, f.FlightNumber, f.DepartureTime, f.ArrivalTime, f.AirplaneId, aps.Model, aps.Seats, aps.Rows, aps.Columns, AirportId_departure, ad.AirportCity AirportCity_d, AirportId_arrival, aa.AirportCity AirportCity_a FROM flights f LEFT JOIN airports aa ON f.AirportId_arrival = aa.AirportName LEFT JOIN airports ad ON f.AirportId_departure = ad.AirportName INNER JOIN airplanes aps ON f.AirplaneId = aps.AirplaneId";

            MySqlConnection dbConn = new MySqlConnection(connectionString);
            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = query;

            try
            {
                dbConn.Open();
            } catch (Exception exc)
            {
                throw exc;
            }

            MySqlDataReader reader = cmd.ExecuteReader();
            lst = await FetchData(reader);
            return lst;

        }


        // SQL Helper
        private async Task<List<Flight>> FetchData(MySqlDataReader reader)
        {
            List<Flight> lst = new List<Flight>();
            try
            {
                while (await reader.ReadAsync())
                {
                    Flight f = new Flight
                    {
                        FlightId = new Guid(reader["FlightsId"].ToString()),
                        FlightNumber = reader["FlightNumber"].ToString(),
                        DepartureTime = Convert.ToDateTime(reader["DepartureTime"]),
                        ArrivalTime = Convert.ToDateTime(reader["ArrivalTime"]),

                        Airplane = new Airplane
                        {
                            AirplaneId = new Guid(reader["AirplaneId"].ToString()),
                            Model = reader["Model"].ToString(),
                            Seats = Convert.ToInt32(reader["Seats"]),
                            Rows = Convert.ToInt32(reader["Rows"]),
                            Columns = Convert.ToInt32(reader["Columns"])
                        },

                        DepartureAirport = new Airport
                        {
                            AirportName = reader["AirportId_departure"].ToString(),
                            AirportCity = reader["AirportCity_d"].ToString()
                        },

                        ArrivalAirport = new Airport
                        {
                            AirportName = reader["AirportId_arrival"].ToString(),
                            AirportCity = reader["AirportCity_a"].ToString()
                        }
                    };

                    lst.Add(f);
                }
            }
            catch (Exception exc)
            {
                //Console.Write(exc.Message); //later loggen
                throw exc;  //in development omgeving
            }
            finally
            {
                reader.Close();
            }
            return lst;
        }
    }
}
