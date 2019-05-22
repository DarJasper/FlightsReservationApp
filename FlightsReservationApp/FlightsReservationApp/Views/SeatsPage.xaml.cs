using FlightsReservationApp.Models;
using FlightsReservationApp.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightsReservationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeatsPage : ContentPage
    {
        Grid grid = new Grid
        {
            //Create row and column definitions
            RowDefinitions = new RowDefinitionCollection(),
            ColumnDefinitions = new ColumnDefinitionCollection()
        };

        public SeatsPage()
        {
            InitializeComponent();
            grid.Children.Clear();
            MessagingCenter.Subscribe<object>(this, "CreateGrid", (sender) => {
                Console.WriteLine("Received message");
                CreateGrid();
            });
            BindingContext = App.ViewModelLocator.SeatsViewModel;
            //Messenger.Default.Send<NotificationMessage>(new NotificationMessage("PageLoaded"));

            
        }

        private void CreateGrid()
        {
            string flightStr = Application.Current.Properties["selectedFlight"].ToString();
            Flights flights = JsonConvert.DeserializeObject<Flights>(flightStr);
            List<Seats> seats = flights.Seats;

            //Count columns and rows
            var rows = seats.Where(item => item.Column == 'A').Count();
            var columns = seats.Where(item => item.Row == 1).Count();

            //Char array to translate column character to a number
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            
            //Loop columns
            for (int rowCount = 0; rowCount < rows; rowCount++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }
            //Loop rows
            for (int columnCount = 0; columnCount < columns; columnCount++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }

            //Loop through seats and create buttons for them
            foreach (var seat in seats)
            {
                bool available = seat.Available;
                string color = "1D79CC";
                if (available == false)
                {
                    color = "D4D5D7";
                }
                
                int columnIndex = alphabet.IndexOf(seat.Column);
                int rowIndex = seat.Row - 1;

                Button btn = new Button
                {
                    Text = seat.Seat,
                    FontSize = 12,
                    HeightRequest = 25,
                    WidthRequest = 25,
                    Padding = 0,
                    IsEnabled = available,
                    BackgroundColor = Color.FromHex(color)
                };
                
                //Check if seat is available -> If so give binding
                if (available == true)
                {
                    btn.TextColor = Color.White;
                    btn.CommandParameter = seat.Seat;
                    btn.SetBinding(Button.CommandProperty, new Binding("SaveReservationCommand"));
                }

                //If col C, space between next col
                if (columnIndex == 2)
                {
                    btn.Margin = new Thickness(0, 0, 10, 0);
                }

                //If 10 seat layout & column = G
                if (columnIndex == 6 && columns == 10)
                {
                    btn.Margin = new Thickness(0, 0, 10, 0);
                }

                //Add btn to the grid
                grid.Children.Add(btn, columnIndex, rowIndex);  
            }
            grid.Margin = 0;
            grid.Padding = 0;
            MyScrollView.Content = grid;
        }
        
    }
}