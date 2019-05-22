using FlightsReservationApp.Models;
using FlightsReservationApp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FlightsReservationApp.ViewModels
{
    public class SeatsViewModel : ViewModelBase
    {
        private readonly ISeatsService _seatsService;
        private readonly ICustomNavigation _navigationService;

        public SeatsViewModel(ISeatsService seatsService, ICustomNavigation navigationService)
        {
            _seatsService = seatsService;
            _navigationService = navigationService;
            
        }



        public string Title
        {
            get
            {
                FetchSeats();
                return "Pick a seat";
            }
        }

        //Button Relays
        public RelayCommand LogoutCommand
        {
            get
            {
                return new RelayCommand(LogoutUser);
            }
        }



        public RelayCommand<string> SaveReservationCommand
        {
            get
            {
                return new RelayCommand<string>((s) => SelectedSeat(s));
            }
        }

        private void LogoutUser()
        {
            if (Application.Current.Properties.ContainsKey("loggedinUser"))
            {
                Application.Current.Properties.Remove("loggedinUser");
            }
            if (Application.Current.Properties.ContainsKey("selectedFlight"))
            {
                Application.Current.Properties.Remove("selectedFlight");
            }
            if (Application.Current.Properties.ContainsKey("selectedSeat"))
            {
                Application.Current.Properties.Remove("selectedSeat");
            }
            _navigationService.NavigateTo("LoginPage");
        }

        private void SelectedSeat(string seat)
        {
            Application.Current.Properties["selectedSeat"] = seat;
            _navigationService.NavigateTo("ConfirmationPage");
        }
       

        private void FetchSeats()
        {
            Console.WriteLine("Fetching seats");
            //Get flight (without seats)
            string flightStr = Application.Current.Properties["selectedFlight"].ToString();
            Flights flights = JsonConvert.DeserializeObject<Flights>(flightStr);
            //Get seats for that flight
            Flights updatedFlight = _seatsService.GetSeats(flights);
            //Add seats to the flight
            flights.Seats = updatedFlight.Seats;
            Console.WriteLine("-------------------------");
            Console.WriteLine(flights.Seats.Count);
            //Save completed object
            string flightString = JsonConvert.SerializeObject(flights);
            Application.Current.Properties["selectedFlight"] = flightString;
            //Create grid now
            CreateGrid();

        }

        

        private void CreateGrid()
        {
            Console.WriteLine("Sending message");
            MessagingCenter.Send<object>(this, "CreateGrid");
        }
    }
}
