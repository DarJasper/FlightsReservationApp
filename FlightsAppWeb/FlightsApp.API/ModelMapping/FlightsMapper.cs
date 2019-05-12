using FlightsApp.API.DTO_s;
using FlightsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsApp.API.ModelMapping
{
    public class FlightsMapper
    {
        public static List<Flights_DTO> ConvertFlightstoDTO (IEnumerable<Flight> Flights, ref List<Flights_DTO> flights_DTOs)
        {
            foreach (Flight flight in Flights)
            {
                Flights_DTO flight_DTO = new Flights_DTO
                {
                    FlightNumber = (flight.FlightNumber is null) ? "" : flight.FlightNumber,
                    DepartureTime = flight.DepartureTime,
                    ArrivalTime = flight.ArrivalTime,

                    ArrivalAirport = new Airports_DTO(),
                    DepartureAirport = new Airports_DTO()
                };
                flight_DTO.ArrivalAirport.AirportName = flight.ArrivalAirport.AirportName ;
                flight_DTO.ArrivalAirport.AirportCity = flight.ArrivalAirport.AirportCity;
                flight_DTO.DepartureAirport.AirportName = flight.DepartureAirport.AirportName;
                flight_DTO.DepartureAirport.AirportCity = flight.DepartureAirport.AirportCity;

                var temp_DTO = new Airplane_DTO
                {
                    Model = flight.Airplane.Model,
                    Seats = flight.Airplane.Seats,
                    Rows = flight.Airplane.Rows,
                    Columns = flight.Airplane.Columns
                };

                flight_DTO.Airplane = temp_DTO;

                flights_DTOs.Add(flight_DTO);
            }
            return flights_DTOs;
        }
    }
}
