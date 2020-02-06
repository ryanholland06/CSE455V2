using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CSE455V2.Models;
using CSE455V2.Views;
using CSE455V2.ViewModels;
using CSE455V2.Services;

namespace CSE455V2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public ItemsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text);
            await firebaseHelper.AddPayment(Convert.ToInt32(txtId.Text), txtName.Text);

            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            var person = await firebaseHelper.GetPerson(Convert.ToInt32(txtId.Text));
            if (person != null)
            {
                txtId.Text = person.PersonId.ToString();
                txtName.Text = person.Name;
                await DisplayAlert("Success", "Person Retrive Successfully", "OK");

            }
            else
            {
                await DisplayAlert("Success", "No Person Available", "OK");
            }

        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.UpdatePerson(Convert.ToInt32(txtId.Text), txtName.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            await DisplayAlert("Success", "Person Updated Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.DeletePerson(Convert.ToInt32(txtId.Text));
            await DisplayAlert("Success", "Person Deleted Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }
    }
}