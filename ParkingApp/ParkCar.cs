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
using Xamarin.Forms;
using ZXing.Mobile;

namespace ParkingApp
{
    [Activity(Label = "ParkCar")]
    public class ParkCar : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ParkCar);
            //We must intlize xamarin forms and mobile barcode scanner here before using them
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);
            Android.Widget.Button scanQRButton = FindViewById<Android.Widget.Button>(Resource.Id.scanQRButton);
            scanQRButton.Click += async (sender, e) =>
            {
                MobileBarcodeScanner.Initialize(Application);

                try
                {
                    var scanner = DependencyService.Get<IQrScanningService>();
                    var result = await scanner.ScanAsync();
                    if (result != null)
                    {
                        string test = result;
                    }
                }
                catch 
                {

                }
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}