using FlightsReservationApp.Models;
using FlightsReservationApp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlightsReservationApp.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly ICustomNavigation _navigationService;
        public RegistrationViewModel(ICustomNavigation navigationService, IUserService userService)
        {
            _userService = userService;
            _navigationService = navigationService;
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

        private string _passwordError;
        public string PasswordError
        {
            get
            {
                return _passwordError;
            }
            set
            {
                _passwordError = value;
                RaisePropertyChanged(() => PasswordError);
            }
        }

        private string _confirmPasswordError;
        public string ConfirmPasswordError
        {
            get
            {
                return _confirmPasswordError;
            }
            set
            {
                _confirmPasswordError = value;
                RaisePropertyChanged(() => ConfirmPasswordError);
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

        public RelayCommand GoToLoginCommand
        {
            get
            {
                return new RelayCommand(GoToLogin);
            }
        }

        private void GoToLogin()
        {
           _navigationService.NavigateTo(ViewModelLocator.LoginPage);
        }
        

        //Button Functions
        private async void RegisterUser()
        {
            if (ValidateEmail() == false || ValidatePassword() == false)
            {
                Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
                return;
            }

            User user = new User() {
                Email = Email,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };
            var x = await _userService.RegisterAsync(user);
            if (x == false)
            {
                EmailError = "This email is already taken.";
            }
            else
            {
                var y = await _userService.Login(user);
                if (y == false)
                {
                    EmailError = "User created, Login Failed.";
                    Vibration.Vibrate(TimeSpan.FromSeconds(0.5));
                    return;
                }
                else
                {
                    Application.Current.Properties["loggedinUser"] = user.Email;
                    _navigationService.NavigateTo(ViewModelLocator.FlightsOverviewPage);
                }
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

        public bool ValidatePassword()
        {
            if (Password == null)
            {
                PasswordError = "The Password field is required.";
                return false;
            }
            if (Password.Length < 6 && Password.Length > 100)
            {
                PasswordError = "The Password must be at least 6 and at max 100 characters long.";
                return false;
            }
            if (!Password.Any(char.IsUpper) || !Password.Any(char.IsDigit) || Password.All(Char.IsLetterOrDigit))
            {
                PasswordError = @"Passwords must have at least one non alphanumeric character.
Passwords must have at least one digit ('0'-'9').
Passwords must have at least one uppercase ('A'-'Z').";
                return false;
            }
            PasswordError = "";
            if (ConfirmPassword != Password)
            {
                ConfirmPasswordError = "The password and confirmation password do not match.";
                return false;                
            }
            ConfirmPasswordError = "";
            return true;
        }
    }
}
