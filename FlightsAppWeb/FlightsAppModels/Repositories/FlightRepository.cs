using FlightsApp.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsApp.Models.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private FlightsAppDbContext _context;
        public FlightRepository(FlightsAppDbContext FlightsAppDbContext)
        {
            _context = FlightsAppDbContext;
        }

        public async Task<List<Flight>> TestFlightsAsync()
        {
            var x = new List<Flight>();
            var a = new Flight();
            var b = new Flight();
            a.FlightId = new Guid("86760699-e531-48fa-8516-3eb5dc14a18e");
            b.FlightId = new Guid("8bc5afba-a6b3-4a92-9666-f5c70d7bcf32");
            a.FlightNumber = "UA 973";
            b.FlightNumber = "DL 141";
            a.DepartureTime = DateTime.Now;
            b.DepartureTime = DateTime.Now;
            a.ArrivalTime = DateTime.Now;
            b.ArrivalTime = DateTime.Now;
            a.Airplane = new Airplane();
            b.Airplane = new Airplane();
            a.Airplane.AirplaneId = new Guid("a4a5013c-29ac-4b57-a865-8c4847a59364");
            b.Airplane.AirplaneId = new Guid("a4a5013c-29ac-4b57-a865-8c4847a59364");
            a.Airplane.Model = "Boeing 777";
            b.Airplane.Model = "Boeing 777";
            a.Airplane.Seats = 100;
            b.Airplane.Seats = 100;
            a.Airplane.Rows = 100;
            b.Airplane.Rows = 100;
            a.Airplane.Columns = 100;
            b.Airplane.Columns = 100;
            a.ArrivalAirport = new Airport();
            b.ArrivalAirport = new Airport();
            a.DepartureAirport = new Airport();
            b.DepartureAirport = new Airport();
            a.ArrivalAirport.AirportName = "BRU";
            b.ArrivalAirport.AirportName = "BRU";
            a.DepartureAirport.AirportName = "BRU";
            b.DepartureAirport.AirportName = "BRU";

            x.Add(a);
            x.Add(b);

            return x;

            return await _context.Flights
                .Include(f => f.Airplane)
                .ToListAsync();
        }

        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await _context.Flights
                .Include(f => f.ArrivalAirport)
                .Include(f => f.DepartureAirport)
                .Include(f => f.Airplane)
                .ToListAsync();
        }

        public List<Flight> GetAllFlights()
        {
            var flights = _context.Flights
                .FromSql(@"SELECT f.FlightsId,
	                            f.FlightNumber,
	                            f.DepartureTime,
                                f.ArrivalTime,
                                f.AirplaneId,
                                aps.Model,
                                aps.Seats,
                                aps.Rows,
                                aps.Columns,
                                AirportId_departure,
                                ad.AirportCity AirportCity_d,
                                AirportId_arrival,
                                aa.AirportCity AirportCity_a
                            FROM flights f LEFT JOIN airports aa
                            ON f.AirportId_arrival = aa.AirportName LEFT JOIN airports ad
                            ON f.AirportId_departure = ad.AirportName
                            INNER JOIN airplanes aps
                            ON f.AirplaneId = aps.AirplaneId")
                .ToList();
            return flights;
        }
    }
}
