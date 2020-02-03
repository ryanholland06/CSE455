using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpotLotSecurityGuard
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnButtonClickedParkingLot(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ParkingLots());
        }

        public async void OnButtonClickedCitations(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Citations());
        }

        public async void OnButtonClickedTowing(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Towing());
        }

        public async void OnButtonClickedAlerts(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecurityAlerts());
        }
    }
}
