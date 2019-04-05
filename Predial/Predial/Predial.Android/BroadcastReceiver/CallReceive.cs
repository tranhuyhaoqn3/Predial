using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Telephony;
using Android.Widget;
using Predial.Droid;
using Java.Lang.Reflect;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using Android.Content.PM;
using System.Threading.Tasks;
using Predial;

using Android.Media;


using System.IO;

using Android.Support.V4.App;
using Android.InputMethodServices;
using Android.Views;
using Android.Content;
using Android.App;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(CallReceive))]

namespace Predial.Droid
{

    [BroadcastReceiver]
    [IntentFilter(new[] { TelephonyManager.ActionPhoneStateChanged})]
    public class CallReceive : BroadcastReceiver
    {
        private string incomingNumber;
        public override void OnReceive(Context context, Intent intent)
        {
            incomingNumber = String.Empty;
            string state = intent.GetStringExtra(TelephonyManager.ExtraState);

            // End Call
            if (state == TelephonyManager.ExtraStateIdle)
            {
            }

            // When outgoing call
            if (state == TelephonyManager.ExtraStateOffhook)
            {
                var incomingPhoneNumber = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                Toast.MakeText(context, $"Incoming Number: {incomingPhoneNumber}", ToastLength.Long).Show();

                CreateNotificationChannel(incomingNumber, context);
            }

            // When phone ring 
            if (state == TelephonyManager.ExtraStateRinging)
            {

            }
            if (state == TelephonyManager.ExtraIncomingNumber)
            {
            }
        }
        static int p = 0;
        private void CreateNotificationChannel(String incommingNumber, Context context)
        {
            context.GetSystemService(Context.InputMethodService);

            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            String NOTIFICATION_CHANNEL_ID = "my_channel_id_01";
            Intent notificationIntent = new Intent(context, typeof(MainActivity));
            notificationIntent.SetFlags(ActivityFlags.ClearTop);
            PendingIntent penintent = PendingIntent.GetActivities(context, 0, new Intent[] { notificationIntent }, 0);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, "Hello", NotificationImportance.Max);

                // Configure the notification channel.
                //notificationChannel.setDescription("Channel description");
                notificationChannel.EnableLights(true);
               
                notificationChannel.SetVibrationPattern(new long[] { 0, 1000, 500, 1000 });
                notificationChannel.EnableVibration(true);
                notificationManager.CreateNotificationChannel(notificationChannel);
            }


            NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(context, NOTIFICATION_CHANNEL_ID);

            notificationBuilder.SetAutoCancel(true)
                    .SetDefaults(Notification.ColorDefault)
                    .SetSmallIcon(Resource.Drawable.plus)
                    .SetPriority((int)NotificationPriority.High)
                    .SetContentTitle("Notification")
                    .SetVibrate(new long[0])
                    .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
                    .SetContentText("End call with Call center")
                   .SetContentIntent(penintent);
            notificationManager.Notify(p, notificationBuilder.Build());
            p++;
        }
    }
}