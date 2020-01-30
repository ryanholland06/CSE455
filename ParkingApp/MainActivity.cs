using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace ParkingApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Button signUpButton = FindViewById<Button>(Resource.Id.btn_signUp);
            Button forgotPasswordButton = FindViewById<Button>(Resource.Id.btn_forgotPassword);
            Button LoginButton = FindViewById<Button>(Resource.Id.btn_login);

            signUpButton.Click += (sender, e) =>
            {
                var signUpIntent = new Intent(this, typeof(MainMenu));
                StartActivity(signUpIntent);
            };
            forgotPasswordButton.Click += (sender, e) =>
            {
                var forgotPasswordIntent = new Intent(this, typeof(MainMenu));
                StartActivity(forgotPasswordIntent);
            };
            LoginButton.Click += (sender, e) =>
            {
                var signUpIntent = new Intent(this, typeof(MainMenu));
                StartActivity(signUpIntent);
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}