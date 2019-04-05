using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
using Predial;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SuaveControls.Views;
using Predial.DatabaseHelper;
using Predial.Model;

namespace Predial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class MainPage : ContentPage 
    {
        public MainPage()
        {
            InitializeComponent();
            Device.BeginInvokeOnMainThread(() =>
            {
                Title = "Predial Plans";
                
            });
            PlanDefault();
        }

        private void PlanDefault()
        {
            PredialPlanDataAccess predialPlanDataAccess = new PredialPlanDataAccess();
            var list=predialPlanDataAccess.GetAllPredialPlans();
            myDemoListView.ItemsSource = list;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMorePlan());
        }
        
        private void MyDemoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            PredialPlanModel predialPlan = myDemoListView.SelectedItem as PredialPlanModel;
            Navigation.PushAsync(new DetailPlan(predialPlan));
        }

        private  void MenuItem1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new AddUserPhoneNumber());
        }
    }
}
