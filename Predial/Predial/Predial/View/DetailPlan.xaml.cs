using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Predial;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Predial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPlan : ContentPage
	{
        UserDataAccess userDataAccess;

        public DetailPlan ()
		{

			InitializeComponent ();
            List<String> mylistDetail = new List<String>();
            mylistDetail.Add("Name");
            mylistDetail.Add("Size");
            mylistDetail.Add("Age");
            mylistDetail.Add("PPP");
            listDetail.ItemsSource = mylistDetail;

     
        }
        private async void btnCall_Clicked(object sender, EventArgs e)
        {
            userDataAccess = new UserDataAccess();
            var user = userDataAccess.GetUser();
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                if (await DisplayAlert("Warning", $"This is your number {user.PhoneNumber}?", "Yes", "No"))
                {
                    string sContentType = "application/json";

                    JObject oJsonObject = new JObject();
                    oJsonObject.Add("PredialPlanID", 9);
                    oJsonObject.Add("CustomerID", 2);

                    oJsonObject.Add("PhoneNumber",user.PhoneNumber);


                    System.Net.Http.HttpContent http = new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType);
                    httpClient.PostAsync("http://192.168.1.101/api/predialplan/makecall", http).Result.ToString();
                }
            }
        }

        private void ImageButtonEdit_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEditSub_Clicked(object sender, EventArgs e)
        {

        }
        private void btnDeleteSub_Clicked(object sender, EventArgs e)
        {

        }
    }
}