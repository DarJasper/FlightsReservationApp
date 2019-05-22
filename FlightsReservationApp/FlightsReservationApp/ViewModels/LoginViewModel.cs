using FlightsReservationApp.Models;
using FlightsReservationApp.Services;
using FlightsReservationApp.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlightsReservationApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ICustomNavigation _navigationService;
        private readonly IUserService _userService;

        public LoginViewModel(ICustomNavigation navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;
        }

        //Initiate Props for Inputs
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        //Error props
        private string _emailError;
        public string EmailError
        {
            get
            {
                return _emailError;
            }
            set
            {
                _emailError = value;
                RaisePropertyChanged(() => EmailError);
            }
        }

        //Button Relays
        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginUser);
            }
        }

        public RelayCommand GoToRegistrationCommand
        {
            get
            {
                return new RelayCommand(GoToRegistration);
            }
        }

        //Button Functions
        private void GoToRegistration()
        {
            _navigationService.NavigateTo(ViewModelLocator.RegistrationPage);
        }

        public async void LoginUser()
        {
            if (ValidateEmail() == false)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
                return;
            }
            User user = new User() { Email = Email};
            var x = await _userService.Login(user);
            if (x == false)
            {
                EmailError = "Incorrect username or password";
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
                return;
            }
            else
            {
                Application.Current.Properties["loggedinUser"] = user.Email;
                _navigationService.NavigateTo(ViewModelLocator.FlightsOverviewPage);
            }
            
        }

        public bool ValidateEmail()
        {
            try
            {
                if (Email == null)
                {
                    EmailError = "The Email field is not a valid e-mail address.";
                    return false;
                }
                MailAddress m = new MailAddress(Email);
                EmailError = "";
                return true;
            }
            catch (FormatException)
            {
                EmailError = "The Email field is not a valid e-mail address.";
                return false;
            }
        }
    }
}
