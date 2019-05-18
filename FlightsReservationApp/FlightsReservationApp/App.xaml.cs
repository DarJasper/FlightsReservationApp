using FlightsReservationApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FlightsReservationApp
{
    public partial class App : Application
    {
        private static ViewModelLocator viewModelLocator;

        public static ViewModelLocator ViewModelLocator
        {
            get
            {
                if (viewModelLocator == null)
                    viewModelLocator = new ViewModelLocator();

                return viewModelLocator;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
