using System;
using System.Threading.Tasks;
using FlightsReservationApp.Models;

namespace FlightsReservationApp.Repositories
{
    public interface ISeatsRepository
    {
        Task<Flights> GetSeats(Guid flightid);
        Task<bool> OrderSeat(Order order);
    }
}