using Android.Content.Res;
using Predial.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Predial
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MainPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#4CB050"),            
            };
            
        }
        public App(int rs)
        {
            PredialPlanModel predialPlanModel = new PredialPlanModel()
            {
                PredialPlanID = 1
            };
            MainPage = new NavigationPage(new MainPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#4CB050"),
            };
            MainPage.Navigation.PushAsync(new DetailPlan(predialPlanModel));
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
          
        }
    }
}
