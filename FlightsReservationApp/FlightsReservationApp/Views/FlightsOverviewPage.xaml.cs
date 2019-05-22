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
	public partial class FlightsOverviewPage : ContentPage
	{
		public FlightsOverviewPage()
		{
            InitializeComponent();
            BindingContext = App.ViewModelLocator.FlightsOverviewViewModel;

            if (Application.Current.Properties.ContainsKey("loggedinUser"))
            {
                string str = Application.Current.Properties["loggedinUser"].ToString();
                Title = "Hello, " + str.Substring(0, str.LastIndexOf("@"));
            }
            else
            {
                Title = "MCT Flights ";
            }
        }
    }
}