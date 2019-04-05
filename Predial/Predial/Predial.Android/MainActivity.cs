using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;



using Android.Support.V4.App;

namespace Predial.Droid
{
    [Activity(Label = "Predial", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        readonly string[] Permission =
        {
            Android.Manifest.Permission.AnswerPhoneCalls,
            Android.Manifest.Permission.ReadPhoneState,
            Android.Manifest.Permission.ReadPhoneNumbers,
            Android.Manifest.Permission.AccessNotificationPolicy,
        };
        const int RequestPhoneID = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                RequestPermissions(Permission, RequestPhoneID);
            }

            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        
        public override void OnBackPressed()
        {
           if(Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            {

            }
           else
            {

            }
        }




    }
}