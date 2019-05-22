using FlightsReservationApp.Models;
using FlightsReservationApp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FlightsReservationApp.ViewModels
{
    public class ConfirmationViewModel : ViewModelBase
    {
        private readonly ISeatsService _seatsService;
        private readonly ICustomNavigation _navigationService;
        private readonly ICityService _cityService;

        public ConfirmationViewModel(ISeatsService seatsService, ICityService cityService, ICustomNavigation navigationService)
        {
            _seatsService = seatsService;
            _navigationService = navigationService;
            _cityService = cityService;
        }

        //Props labels
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
                Console.WriteLine(GetSelectFlight().DepartureTime.ToString("hh:mm tt"));
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

        private string _seat;
        public string Seat
        {
            get
            {
                return GetSeat();
            }
            set
            {
                _seat = value;
                RaisePropertyChanged(() => Seat);
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

        public RelayCommand ConfirmOrder
        {
            get
            {
                return new RelayCommand(Confirmation);
            }
        }

        public RelayCommand CancelOrder
        {
            get
            {
                return new RelayCommand(Cancellation);
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

        private void Confirmation()
        {
            Console.WriteLine(_seatsService.ReserveSelectedSeat());
        }

        private void Cancellation()
        {

            if (Application.Current.Properties.ContainsKey("selectedFlight"))
            {
                Application.Current.Properties.Remove("selectedFlight");
            }
            if (Application.Current.Properties.ContainsKey("selectedSeat"))
            {
                Application.Current.Properties.Remove("selectedSeat");
            }
            _navigationService.NavigateTo("FlightsOverviewPage");
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
            var x = _cityService.GetImage(city);
            Console.WriteLine(x);
            return x;
        }

        public string GetSeat()
        {
            return Application.Current.Properties["selectedSeat"].ToString();
        }
    }
}
