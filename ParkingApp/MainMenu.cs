﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ParkingApp
{
    [Activity(Label = "MainMenu")]
    public class MainMenu : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);
            Button parkCarButton = FindViewById<Button>(Resource.Id.ParkCarButton);
            parkCarButton.Click += (sender, e) =>
            {
                var parkCarIntent = new Intent(this, typeof(ParkCar));
                StartActivity(parkCarIntent);
            };


            // Create your application here
        }
    }
}