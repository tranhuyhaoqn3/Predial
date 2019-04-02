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

        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            userDataAccess = new UserDataAccess();


            UserModel user = new UserModel
            {
                PhoneNumber = PhoneEntry.Text
            };
            if (userDataAccess.UpdateUser(user))
            {
                DependencyService.Get<IShowAlert>().ShowAlert("Your phone number have been saved !!!!");
               
            }
            else
            {
                 DisplayAlert("Something Wrong", "We can not save your phone number", "Cancel");
            }
            
        }
    }
}