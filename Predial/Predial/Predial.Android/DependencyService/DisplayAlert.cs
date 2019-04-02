﻿using System;
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

[assembly: Xamarin.Forms.Dependency(typeof(DisplayAlert))]
namespace Predial.Droid
{
    
    public class DisplayAlert : IShowAlert
    {
        
        public void ShowAlert(string message)
        {
            var builder = new AlertDialog.Builder(Xamarin.Forms.Forms.Context);
            builder.SetMessage(message);
            builder.SetPositiveButton("OK", (sender, args) => { });
            builder.SetCancelable(false);
            
            builder.Show();
        }

         
    }
}