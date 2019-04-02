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

            List<String> myListString = new List<String>();

            myListString.Add("Call AK Sotor Service");
            myListString.Add("Bolton Health Care");
            myListString.Add("Apple Texas Sale Service");
            myListString.Add("WorldCup 2022");
            myDemoListView.ItemsSource = myListString;

       
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMorePlan());
        }
        
        private void MyDemoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            
            Navigation.PushAsync(new DetailPlan());
        }

        private  void MenuItem1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new AddUserPhoneNumber());
        }
    }
}
