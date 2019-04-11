using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predial;
using Rg.Plugins.Popup.Pages;
using Newtonsoft.Json.Linq;

using System.Net.Http;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;

namespace Predial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddUserPhoneNumber : PopupPage
	{
        UserDataAccess userDataAccess;
        public AddUserPhoneNumber()
        {
            InitializeComponent();
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(PhoneEntry.Text) || !PhoneEntry.Text.All(char.IsDigit))
            {
              await  DisplayAlert("Alert", "Please fill correct phone number", "OK");
                PhoneEntry.Focus();
                return;
            }
            userDataAccess = new UserDataAccess();
            UserModel user = new UserModel
            {
                PhoneNumber = PhoneEntry.Text
            };
            if (userDataAccess.UpdateUser(user))
            {
                await DisplayAlert("Alert", "We can not save your phone number", "OK");
                await Navigation.PopPopupAsync();
            }
            else
            {
               await  DisplayAlert("Something Wrong", "We can not save your phone number", "Cancel");
            }
            
        }
    }
}