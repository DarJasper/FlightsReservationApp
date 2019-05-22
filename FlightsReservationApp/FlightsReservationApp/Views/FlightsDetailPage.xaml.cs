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
	public partial class FlightsDetailPage : ContentPage
	{
		public FlightsDetailPage ()
		{
			InitializeComponent ();
            BindingContext = App.ViewModelLocator.FlightsDetailViewModel;
        }
	}
}