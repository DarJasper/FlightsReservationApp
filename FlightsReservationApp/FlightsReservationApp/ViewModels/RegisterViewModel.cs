using FlightsReservationApp.Models;
using FlightsReservationApp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsReservationApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        public RegisterViewModel(IUserService userService)
        {
            this._userService = userService;
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

        private string _confirmpassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmpassword;
            }
            set
            {
                _confirmpassword = value;
                RaisePropertyChanged(() => ConfirmPassword);
            }
        }
                             
        //Button Relays
        public RelayCommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterUser);
            }
        }

        //Button Functions
        private void RegisterUser()
        {
            Console.WriteLine("Pressed Button");
            User user = new User() {
                Email = Email,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };
            _userService.RegisterAsync(user);

        }
    }
}
