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
using SQLiteDB.Resources.Model;

namespace ParkingApp
{
    [Activity(Label = "CreateAccount")]
    class CreateAccount : Activity
    {

        //ListView lstViewData;
        List<Person> listSource = new List<Person>();
        Database db ;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.CreateAccount);
            //Create Database  
            db = new Database();
            db.createDatabase();
            //lstViewData = FindViewById<ListView>(Resource.Id.listView);
            var edtName = FindViewById<EditText>(Resource.Id.edtName);
            var passwordInput = FindViewById<EditText>(Resource.Id.edtPassword);
            var edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            var edtStudentID = FindViewById<EditText>(Resource.Id.edtStudentID);

            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            //var btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            //var btnRemove = FindViewById<Button>(Resource.Id.btnRemove);
            ////Load Data
            LoadData();
            //Event
            btnAdd.Click += delegate
            {
                Person person = new Person()
                {
                    Name = edtName.Text,
                    Password = passwordInput.Text,
                    StudentID = edtStudentID.Text,
                    Email = edtEmail.Text
                };
                db.insertIntoTable(person);
                LoadData();
                var mainMenuIntent = new Intent(this, typeof(MainActivity));
                StartActivity(mainMenuIntent);

            };
            //btnEdit.Click += delegate
            //{
            //    Person person = new Person()
            //    {
            //        Id = int.Parse(edtName.Tag.ToString()),
            //        Name = edtName.Text,
            //        Password = passwordInput.Text,
            //        Email = edtEmail.Text
            //    };
            //    db.updateTable(person);
            //    LoadData();
            //};
            //btnRemove.Click += delegate
            //{
            //    try
            //    {
            //        Person person = new Person()
            //        {
            //            Id = int.Parse(edtName.Tag.ToString()),
            //            Name = edtName.Text,
            //            Password = passwordInput.Text,
            //            Email = edtEmail.Text
            //        };
            //        db.removeTable(person);
            //        LoadData();
            //    }
            //    catch
            //    {

            //    }
            //};
            //lstViewData.ItemClick += (s, e) =>
            //{
            //    //Set Backround for selected item
            //    for (int i = 0; i < lstViewData.Count; i++)
            //        {
            //            if (e.Position == i)
            //                lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Black);
            //            else
            //                lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
            //        }
            //    //Binding Data
            //    var txtName = e.View.FindViewById<TextView>(Resource.Id.txtView_Name);
            //    var txtPassword = e.View.FindViewById<TextView>(Resource.Id.txtView_Password);
            //    var txtEmail = e.View.FindViewById<TextView>(Resource.Id.txtView_Email);
            //    edtEmail.Text = txtName.Text;
            //    edtName.Tag = e.Id;
            //    passwordInput.Text = txtPassword.Text;
            //    edtEmail.Text = txtEmail.Text;
            //};
        }
        private void LoadData()
        {
            listSource = db.selectTable();
            //var adapter = new ListViewAdapter(this, listSource);
            //lstViewData.Adapter = adapter;
        }
    }
}
