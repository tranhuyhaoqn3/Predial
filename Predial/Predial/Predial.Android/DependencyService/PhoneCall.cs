using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Predial.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCall))]
namespace Predial.Droid
{
    public class PhoneCall : IPhoneCall
    {
        public void MakeCall(string phoneNumber)
        {
            try
            {
          
                var URI = Android.Net.Uri.Parse(string.Format("tel:{0}", phoneNumber));
                var intent = new Intent(Intent.ActionCall, URI);
#pragma warning disable CS0618 // Type or member is obsolete
                Xamarin.Forms.Forms.Context.StartActivity(intent);
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}