using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;

namespace ParkingApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<Person> listSource = new List<Person>();
        public Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            db = new Database();
            db.createDatabase();
            LoadData();

            Button signUpButton = FindViewById<Button>(Resource.Id.btn_signUp);
            Button forgotPasswordButton = FindViewById<Button>(Resource.Id.btn_forgotPassword);
            Button LoginButton = FindViewById<Button>(Resource.Id.btn_login);

            TextView passwordInput = FindViewById<TextView>(Resource.Id.input_password);
            TextView emailInput = FindViewById<TextView>(Resource.Id.input_email);


            signUpButton.Click += (sender, e) =>
            {
                LoadData();

                var signUpIntent = new Intent(this, typeof(CreateAccount));
                StartActivity(signUpIntent);
            };
            forgotPasswordButton.Click += (sender, e) =>
            {
                LoadData();

                var forgotPasswordIntent = new Intent(this, typeof(MainMenu));
                StartActivity(forgotPasswordIntent);
            };
            LoginButton.Click += (sender, e) =>
            {
                LoadData();
                var signUpIntent = new Intent(this, typeof(MainMenu));
                bool isValidUser = false;
                foreach(var user in listSource)
                {
                    if (user.Password == passwordInput.Text && user.Email == emailInput.Text)
                        isValidUser = true;
                }
                if(isValidUser)
                    StartActivity(signUpIntent);
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void LoadData()
        {
            listSource = db.selectTable();
        }
    }
}