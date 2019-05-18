using FlightsReservationApp.Repositories;
using FlightsReservationApp.Services;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsReservationApp.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IUserRepository, UserRepository>();

            SimpleIoc.Default.Register<IUserService, UserService>();

            SimpleIoc.Default.Register<RegisterViewModel>();
        }

        public RegisterViewModel RegisterViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<RegisterViewModel>();
            }
        }
    }
}
