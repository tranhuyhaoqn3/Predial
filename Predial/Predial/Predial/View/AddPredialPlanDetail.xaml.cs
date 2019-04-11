    using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Predial.DatabaseHelper;
using Predial.Model;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Predial.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPredialPlanDetail : PopupPage
    {
        PredialPlanDataAccess planDataAccess;
        public event EventHandler AddSucceeded;
        PredialPlanModel predialPlanModel;
        UserDataAccess UserDataAccess;
        PredialPlanDetailDataAccess predialPlanDetailDataAccess;
        int stepPredialPlanDetail;
		public AddPredialPlanDetail (PredialPlanModel predialPlan)
		{
			InitializeComponent ();
            predialPlanModel = predialPlan;
            UserDataAccess = new UserDataAccess();
            predialPlanDetailDataAccess = new PredialPlanDetailDataAccess();
            planDataAccess = new PredialPlanDataAccess();
        }
        public void setStep(int step)
        {
            stepPredialPlanDetail = step+1;
        }
        private void Save_Clicked(object sender, EventArgs e)
        {
            if (CheckInput() != true) return;
            PredialPlanDetailModel predialPlanDetailModel = new PredialPlanDetailModel()
            {
                ClientPredialPlanID = predialPlanModel.PredialPlanID,
                WaitingSeconds = Int32.Parse(WaitSecond.Text),
                Key=PressKey.Text,
                Step= stepPredialPlanDetail
            };
            predialPlanDetailDataAccess.InsertPredialPlanDetail(predialPlanDetailModel);

            if(predialPlanModel.KeyPressed != null)
            {
               predialPlanModel.KeyPressed = String.Concat(predialPlanModel.KeyPressed, "-", predialPlanDetailModel.Key);
            }
            else
            {
                predialPlanModel.KeyPressed = String.Concat(predialPlanDetailModel.Key);
            }
            planDataAccess.UpdatePredialPlan(predialPlanModel);
            var user = UserDataAccess.GetUser();
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                string sContentType = "application/json";
                JObject oJsonObject = new JObject();
                oJsonObject.Add("PredialPlanID", predialPlanModel.PredialPlanID);
                oJsonObject.Add("PredialPlanName", predialPlanModel.PredialPlanName);
                oJsonObject.Add("CallCenterNumber", predialPlanModel.CallCenterNumber);
                oJsonObject.Add("KeysPressed", predialPlanModel.KeyPressed);

                oJsonObject.Add("CustomerID", user.ID);
                oJsonObject.Add("TransferToNumber", user.PhoneNumber);
                System.Net.Http.HttpContent http = new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType);
              var rs=  httpClient.PostAsync("http://192.168.1.101/api/predialplan", http).Result.ToString();
            }
            var listdetail = predialPlanDetailDataAccess.GetPredialPlansDetail(predialPlanModel);
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                string sContentType = "application/json";

                JObject oJsonObject = new JObject();
                oJsonObject.Add("CustomerID", user.ID);
                JToken json = JsonConvert.SerializeObject(listdetail);
                oJsonObject.Add("Detail", json);
                oJsonObject.Add("PredialPlanID", predialPlanModel.PredialPlanID);
                oJsonObject.Add("KeysPressed", predialPlanModel.KeyPressed);
                System.Net.Http.HttpContent http = new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType);
                var rs = httpClient.PostAsync("http://192.168.1.36:49578/api/detail", http).Result.ToString();
            }
            Navigation.PopPopupAsync();
            OnAddSucceeded();
        }
        private bool CheckInput()
        {
            if (String.IsNullOrWhiteSpace(PressKey.Text))
            {
                DisplayAlert("Alert", "Please fill Press Key", "OK");
                PressKey.Focus();
                return false;
            }
            if (String.IsNullOrWhiteSpace(WaitSecond.Text) || !WaitSecond.Text.All(char.IsDigit))
            {
                DisplayAlert("Alert", "Please fill correct Wait Second", "OK");
                WaitSecond.Focus();
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