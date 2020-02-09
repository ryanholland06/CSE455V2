using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CSE455V2.ViewModel;

namespace CSE455V2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
		WelcomePageVM welcomePageVM;
		public WelcomePage(string email)
		{
			InitializeComponent();
			welcomePageVM = new WelcomePageVM(email);
			BindingContext = welcomePageVM;
		}
	}
}