using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using CSE455V2.Services;
using CSE455V2.Models;

namespace CSE455V2.Views.SecurityViews
{
    public partial class CitationDetails : ContentPage
    {
        readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        public CitationDetails(Citations citation)
        {
            InitializeComponent();

            if (citation == null)
                DisplayAlert("Error", "Null", "OK");
            else
                DisplayAlert("Sucees", "Citation " + citation.CitationId + " Returned!", "Ok");

            

        }
    }
}