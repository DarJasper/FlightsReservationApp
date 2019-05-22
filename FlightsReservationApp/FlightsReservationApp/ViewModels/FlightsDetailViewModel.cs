using FlightsReservationApp.Models;
using FlightsReservationApp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightsReservationApp.ViewModels
{
    public class FlightsDetailViewModel : ViewModelBase
    {
        private readonly ICustomNavigation _navigationService;
        private readonly ICityService _service;

        public FlightsDetailViewModel(ICustomNavigation navigationService, ICityService cityService)
        {
            _navigationService = navigationService;
            _service = cityService;
        }

        //Page bindings
        private string _depairport;
        public string DepAirport
        {
            get
            {
                return GetSelectFlight().DepartureAirport.Name;
            }
            set
            {
                _depairport = value;
                RaisePropertyChanged(() => DepAirport);
            }
        }

        private string _image;
        public string Image
        {
            get
            {
                return GetImage();
            }
            set
            {
                _image = value;
                RaisePropertyChanged(() => Image);
            }
        }

        private string _arrairport;
        public string ArrAirport
        {
            get
            {
                return GetSelectFlight().ArrivalAirport.Name;
            }
            set
            {
                _arrairport = value;
                RaisePropertyChanged(() => ArrAirport);
            }
        }

        private string _depcity;
        public string DepCity
        {
            get
            {
                return GetSelectFlight().DepartureAirport.City;
            }
            set
            {
                _depcity = value;
                RaisePropertyChanged(() => DepCity);
            }
        }

        private string _arrcity;
        public string ArrCity
        {
            get
            {
                return GetSelectFlight().ArrivalAirport.City;
            }
            set
            {
                _arrcity = value;
                RaisePropertyChanged(() => ArrCity);
            }
        }

        private string _flightdate;
        public string FlightDate
        {
            get
            {
                return GetSelectFlight().DepartureTime.ToString("dd MMM, yyyy");
            }
            set
            {
                _flightdate = value;
                RaisePropertyChanged(() => FlightDate);
            }
        }

        private string _deptime;
        public string DepTime
        {
            get
            {
                return GetSelectFlight().DepartureTime.ToString("hh:mm tt");
            }
            set
            {
                _deptime = value;
                RaisePropertyChanged(() => DepTime);
            }
        }

        private string _arrtime;
        public string ArrTime
        {
            get
            {
                return DateDifference();
            }
            set
            {
                _arrtime = value;
                RaisePropertyChanged(() => ArrTime);
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

        public RelayCommand GoToSeatsCommand
        {
            get
            {
                return new RelayCommand(GoToSeats);
            }
        }


        //Button Functions
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

        private void GoToSeats()
        {
            _navigationService.NavigateTo("SeatsPage");
        }

        //Other Functions
        private Flights GetSelectFlight()
        {
            string flightString = Application.Current.Properties["selectedFlight"].ToString();
            Flights flight = JsonConvert.DeserializeObject<Flights>(flightString);
            return flight;
        }

        private string DateDifference()
        {
            Flights flight = GetSelectFlight();
            if (flight.DepartureTime.Date != flight.ArrivalTime.Date)
                return flight.ArrivalTime.ToString("hh:mm tt") + "+1";
            return flight.ArrivalTime.ToString("hh:mm tt");
        }

        public string GetImage()
        {
            string city = GetSelectFlight().ArrivalAirport.City;
            //string img = Task.Run(() => _service.GetImage(city)).Result;
            var x = _service.GetImage(city);
            Console.WriteLine(x);
            return x;
        }
    }
}
