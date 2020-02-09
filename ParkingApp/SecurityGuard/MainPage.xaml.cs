using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace FIrebaseTest2
{
    public partial class MainPage : ContentPage
    {
        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }

        /*
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var person = await firebaseHelper.GetPerson(Convert.ToInt32(txtVin.Text));
            showResult.Text = person.Name;
        }
        

        public async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text, Convert.ToInt64(txtVin.Text), txtVehicle.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtVin.Text = string.Empty;
            txtVehicle.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Sucessfully", "Ok");
            //var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }
        */

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            var person = await firebaseHelper.GetPerson(Convert.ToInt64(searchVin.Text));
            if (!IsVinValid())
            {
                await DisplayAlert("Error", "Required Field Incorrect or Missing", "Ok");
                return;
            }
            else if (person != null)
            {
                personName.Text = person.Name;
                vinNumber.Text = person.VinNum.ToString();
                vehicleInfo.Text = person.VehicleInformation;

                //lstPerson.ItemsSource = person.Name;
                //await DisplayAlert("Sucess", "Person Retrieve Successfully", "Ok");
            }
            else
            {
                await DisplayAlert("Success", "No Person Available", "Ok");
            }
        }

        public async void OnButtonClickAddCitation(object sender, EventArgs e)
        {
            var person = await firebaseHelper.GetPerson(Convert.ToInt64(searchVin.Text));
            int fine = 50;
            bool paid = false;

            //NEED TO ADD NUMBER OF CITATIONS PER USER AND CITATION NUMBER
            //ALSO A WAY TO CHECK IF USER HAS ANY PREVIOUS CITATIONS
            //NEED TO ADD REASON FOR CITATION
            await firebaseHelper.AddCitation(vehicleInfo.Text, Convert.ToInt64(searchVin.Text), person.PersonId, personName.Text, fine, paid);

            //NAVIGATE TO PREVIOUS PAGE

            await DisplayAlert("Confirmation", "Citation Submitted", "Ok");
        }

        //private bool IsFormValid() => IsVinValid();

        private bool IsVinValid() => (searchVin.Text).ToString().Length == 17 && !string.IsNullOrWhiteSpace(searchVin.Text);


    }
}
