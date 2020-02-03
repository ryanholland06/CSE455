using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Karumi.Dexter;
using ParkingApp.Services;
//using Xamarin.Forms;  // Button doesnt work when this is on.
using ZXing.Mobile;

namespace ParkingApp
{
    [Activity(Label = "UserSettings")]
    class UserSettings : Activity 
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserSettings);

            Button payment = FindViewById<Button>(Resource.Id.payment_info);
            payment.Click += (sender, e) =>
            {
                var payTime = new Intent(this, typeof(Payment));
                StartActivity(payTime);
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}