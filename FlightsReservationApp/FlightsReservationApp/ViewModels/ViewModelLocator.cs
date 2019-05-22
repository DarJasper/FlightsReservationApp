using FlightsReservationApp.Repositories;
using FlightsReservationApp.Services;
using FlightsReservationApp.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightsReservationApp.ViewModels
{
    public class ViewModelLocator
    {
        public const string LoginPage = "LoginPage";
        public const string RegistrationPage = "RegistrationPage";
        public const string FlightsOverviewPage = "FlightsOverviewPage";
        public const string FlightsDetailPage = "FlightsDetailPage";
        public const string SeatsPage = "SeatsPage";
        public const string ConfirmationPage = "ConfirmationPage";

        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IUserRepository, UserRepository>();
            SimpleIoc.Default.Register<IFlightsRepository, FlightsRepository>();
            SimpleIoc.Default.Register<IAirportsRepository, AirportsRepository>();
            SimpleIoc.Default.Register<ICitiesRepository, CitiesRepository>();
            SimpleIoc.Default.Register<ISeatsRepository, SeatsRepository>();

            SimpleIoc.Default.Register<IUserService, UserService>();
            SimpleIoc.Default.Register<IFlightsService, FlightsService>();
            SimpleIoc.Default.Register<IAirportsService, AirportsService>();
            SimpleIoc.Default.Register<ICityService, CityService>();
            SimpleIoc.Default.Register<ISeatsService, SeatsService>();

            SimpleIoc.Default.Register<RegistrationViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<FlightsOverviewViewModel>();
            SimpleIoc.Default.Register<FlightsDetailViewModel>();
            SimpleIoc.Default.Register<SeatsViewModel>();
            SimpleIoc.Default.Register<ConfirmationViewModel>();
        }

        public RegistrationViewModel RegistrationViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<RegistrationViewModel>();
            }
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<LoginViewModel>();
            }
        }

        public FlightsOverviewViewModel FlightsOverviewViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<FlightsOverviewViewModel>();
            }
        }

        public FlightsDetailViewModel FlightsDetailViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<FlightsDetailViewModel>();
            }
        }

        public SeatsViewModel SeatsViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<SeatsViewModel>();
            }
        }

        public ConfirmationViewModel ConfirmationViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ConfirmationViewModel>();
            }
        }
    }
}
