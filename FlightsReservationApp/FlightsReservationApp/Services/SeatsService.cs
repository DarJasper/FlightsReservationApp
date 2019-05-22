using FlightsReservationApp.Models;
using FlightsReservationApp.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightsReservationApp.Services
{
    public class SeatsService : ISeatsService
    {
        private readonly ISeatsRepository _repo;
        private readonly IUserRepository _userRepo;

        public SeatsService(ISeatsRepository repo, IUserRepository repo2)
        {
            _repo = repo;
            _userRepo = repo2;
        }

        public Flights GetSeats(Flights flight)
        {
            return Task.Run(() => _repo.GetSeats(flight.Id)).Result;
        }

        public Order FetchOrderForm(string email)
        {
            return Task.Run(() => _userRepo.GetOrderForm(email)).Result;
        }

        public async Task<bool> ReserveSelectedSeat()
        {
            //GET USERID
            string loggedInUser = Application.Current.Properties["loggedinUser"].ToString();
            //GET ORDER FORM
            Order OrderForm = FetchOrderForm(loggedInUser);
            //GET ALL SEATS OF THE SELECTED FLIGHT
            string flightStr = Application.Current.Properties["selectedFlight"].ToString();
            Flights flights = JsonConvert.DeserializeObject<Flights>(flightStr);
            List<Seats> seats = flights.Seats;
            //GET THE SELECTED SEAT
            string selectedSeat = Application.Current.Properties["selectedSeat"].ToString();
            //FIND THE ID OF THE SELECTED SEAT
            Seats selectedSeatObj = new Seats();
            foreach (Seats seat in seats)
            {
                if (seat.Row.ToString() == selectedSeat.Substring(0,1) && seat.Column.ToString() == selectedSeat.Substring(1, 1))
                {
                    Console.WriteLine("Found the match!");
                    selectedSeatObj = seat;
                }
            }
            //ADD SEAT TO ORDER FORM
            OrderForm.Tickets = new List<Tickets>
            {
                [0] = new Tickets
                {
                    FlightId = flights.Id,
                    SeatId = selectedSeatObj.Id,
                }
            };

            return await _repo.OrderSeat(OrderForm);
        }
    }
}
