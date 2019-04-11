using Newtonsoft.Json.Linq;
using Predial.DatabaseHelper;
using Predial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Predial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddMorePlan : ContentPage
	{
        public event EventHandler AddSucceeded;
        public AddMorePlan ()
		{
			InitializeComponent ();
		}

        private async  void btnSave_Clicked(object sender, EventArgs e)
        {
            if(CheckInput())
            {
                PredialPlanModel predialPlanModel = new PredialPlanModel()
                {
                    CallCenterNumber = entNumber.Text,
                    PredialPlanName = entTitle.Text
                };
                PredialPlanDataAccess predialPlanDataAccess = new PredialPlanDataAccess();

                if (predialPlanDataAccess.InsertPredialPlan(predialPlanModel))
                {
                   await  DisplayAlert("Alert", "Adding successfully", "OK");
                   await  Navigation.PopAsync();
                    OnAddSucceeded();
                }
                else
                {
                    await DisplayAlert("Alert", "Adding unsuccessfully", "OK");
                }
            }
        }
        private bool CheckInput()
        {
            if (String.IsNullOrWhiteSpace(entTitle.Text))
            {
                DisplayAlert("Alert", "Please fill plan title", "OK");
                entTitle.Focus();
                return false;
            }
            if (String.IsNullOrWhiteSpace(entNumber.Text) || !entNumber.Text.All(char.IsDigit))
            {
                DisplayAlert("Alert", "Please fill correct phone number", "OK");
                entNumber.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private void OnAddSucceeded()
        {
            if (AddSucceeded != null)
            {
                AddSucceeded(this, EventArgs.Empty);
            }
        }
    }
}