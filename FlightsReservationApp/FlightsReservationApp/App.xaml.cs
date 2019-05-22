using FlightsReservationApp.Services;
using FlightsReservationApp.ViewModels;
using FlightsReservationApp.Views;
using GalaSoft.MvvmLight.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FlightsReservationApp
{
    public partial class App : Application
    {        
        private static ViewModelLocator _viewModelLocator;
        public static ViewModelLocator ViewModelLocator
        {
            get
            {
                return _viewModelLocator ?? (_viewModelLocator = new ViewModelLocator());
            }
        }

        public App()
        {
            InitializeComponent();
            // Setup Nav service
            var nav = new NavigationService();
            nav.Configure(ViewModelLocator.RegistrationPage, typeof(RegistrationPage));
            nav.Configure(ViewModelLocator.LoginPage, typeof(LoginPage));
            nav.Configure(ViewModelLocator.FlightsOverviewPage, typeof(FlightsOverviewPage));
            nav.Configure(ViewModelLocator.FlightsDetailPage, typeof(FlightsDetailPage));
            nav.Configure(ViewModelLocator.SeatsPage, typeof(SeatsPage));
            nav.Configure(ViewModelLocator.ConfirmationPage, typeof(ConfirmationPage));

            if (!SimpleIoc.Default.IsRegistered<ICustomNavigation>())
            {
                SimpleIoc.Default.Register<ICustomNavigation>(() => nav);
            }

            if (Application.Current.Properties.ContainsKey("loggedinUser"))
            {
                var mainPage = new NavigationPage(new FlightsOverviewPage());
                nav.Initialize(mainPage);
                mainPage.BarBackgroundColor = Color.FromHex("472F92");
                MainPage = mainPage;
            }
            else
            {
                var mainPage = new NavigationPage(new LoginPage());
                nav.Initialize(mainPage);
                mainPage.BarBackgroundColor = Color.FromHex("472F92");
                MainPage = mainPage;
            }               
            
            
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
