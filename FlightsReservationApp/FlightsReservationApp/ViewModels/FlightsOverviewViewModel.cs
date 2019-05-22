using FlightsReservationApp.Models;
using FlightsReservationApp.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace FlightsReservationApp.ViewModels
{
    public class FlightsOverviewViewModel : ViewModelBase
    {
        private readonly ICustomNavigation _navigationService;
        private readonly IFlightsService _flightsService;
        private readonly IAirportsService _airportsService;

        public FlightsOverviewViewModel(ICustomNavigation navigationService, IFlightsService flightsService, IAirportsService airportsService)
        {
            _navigationService = navigationService;
            _flightsService = flightsService;
            _airportsService = airportsService;
        }

        //Properties voor list tonen in Pickers
        public List<Airports> Airports
        {
            get
            {
                return _airportsService.GetAllAirports();
            }
        }

        //Properties voor geselecteerde item van picker
        private Airports _selectedAirport;
        public Airports SelectedAirport
        {
            get
            {
                return _selectedAirport;
            }
            set
            {
                _selectedAirport = value;
                RaisePropertyChanged(() => SelectedAirport);
                UpdateFlights(SelectedAirport);
            }
        }

        private ObservableCollection<Flights> flights;
        public ObservableCollection<Flights> Flights
        {
            get
            {
                return flights;
            }
            set
            {
                flights = value;
                RaisePropertyChanged(() => Flights);
            }
        }

        private Flights _selectedFlights;
        public Flights SelectedFlight
        {
            get
            {
                return _selectedFlights;
                
            }
            set
            {
                _selectedFlights = value;
                RaisePropertyChanged(() => SelectedFlight);
                if (SelectedFlight != null)
                    SelectAFlight();

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

        private void SelectAFlight()
        {
            string flightString = JsonConvert.SerializeObject(SelectedFlight);
            Application.Current.Properties["selectedFlight"] = flightString;
            SelectedFlight = null;
            _navigationService.NavigateTo(ViewModelLocator.FlightsDetailPage);
        }

        //Functions
        private async void UpdateFlights(Airports airport)
        {

            List<Flights> flightsList = await _flightsService.GetFlightsTo(airport);
            ObservableCollection<Flights> flightsCollection = new ObservableCollection<Flights>(flightsList);
            Flights = flightsCollection;
        }
    }
}
