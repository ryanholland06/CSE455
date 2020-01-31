using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ParkingApp.Models;

namespace ParkingApp.DB
{
    [Activity(Label = "SignUp")]
    public class SignUp : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SignUp);

            User users = new User();
            UserDB userDB = new UserDB();

            Button signUpButton = FindViewById<Button>(Resource.Id.btn_signUp);
            EditText emailEntry = FindViewById<EditText>(Resource.Id.input_email);
            EditText passwordEntry = FindViewById<EditText>(Resource.Id.input_password);


            signUpButton.Click += (sender, e) =>
            {
                users.name = emailEntry.Text;
                users.userName = emailEntry.Text;
                users.password = passwordEntry.Text;
                try
                {
                    var retrunvalue = userDB.AddUser(users);
                    if (retrunvalue == "Sucessfully Added")
                    {
                        //await DisplayAlert("User Add", retrunvalue, "OK");
                        //await Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        //await DisplayAlert("User Add", retrunvalue, "OK");
                        //warningLabel.IsVisible = false;
                        emailEntry.Text = string.Empty;
                        //userNameEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;
                        //confirmpasswordEntry.Text = string.Empty;
                        //phoneEntry.Text = string.Empty;
                    }
                }
                catch 
                {
                }

            };

            // Create your application here
        }
    }
}