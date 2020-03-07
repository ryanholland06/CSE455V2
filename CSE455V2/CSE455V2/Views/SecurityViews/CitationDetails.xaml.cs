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

            name.Text = "Name: " + citation.Name;

            studentId.Text = "Student ID: " + citation.StudentId.ToString();

            vehicleInfo.Text = "Vehicle Information: " + citation.VehicleInfo;

            lisencePlate.Text = "License Plate: " + citation.LisencePlate;

            citationId.Text = "Citation ID: " + citation.CitationId.ToString();

            reasonForCitation.Text = "Reason for Citation: " + citation.ReasonForCitation;

            fineAmount.Text = "Fine Amount: " + citation.FineAmount.ToString();

            paidStatus.Text = "Paid Status: " + citation.PaidStatus.ToString();
                                 

        }
    }
}