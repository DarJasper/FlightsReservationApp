using GalaSoft.MvvmLight.Views;
using System;
using Xamarin.Forms;

namespace FlightsReservationApp.Services
{
    public interface ICustomNavigation : INavigationService
    {
        void Configure(string pageKey, Type pageType);
        void Initialize(NavigationPage navigation);
    }
}