using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;


namespace ParkingApp
{
    [Activity(Label = "Payment")]
    public class Payment : Activity
    {
        class paymentMethod
        {
            public paymentMethod(string cardHolderName, int cardNumbers, DateTime expDate, int securityCode)
            {
                this.Name = cardHolderName;
                this.Numbers = cardNumbers;
                this.Experation = expDate;
                this.Secure = securityCode;
            }

            public string Name { private set; get; }

            public int Numbers { private set; get; }

            public DateTime Experation { private set; get; }

            public int Secure { private set; get; }
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            bool answer;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Payment);

            Button editPayment = FindViewById<Button>(Resource.Id.add_or_change);

            editPayment.Click += async (sender, e) =>
            {
                //(sender as Button).Text = "I was just clicked!";

            };
        }
        /*private async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        }*/
    }
}