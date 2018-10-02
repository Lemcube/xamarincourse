using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Course.DataAccess.Interfaces;

namespace Course.DataAccess.Droid
{
    public class AndroidNetworkMonitor : INetworkMonitor
    {
        public bool IsOnline()
        {
            ConnectivityManager connectivityManager =
            (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            bool isConnected = connectivityManager.ActiveNetworkInfo != null
            && connectivityManager.ActiveNetworkInfo.IsConnected;

            return isConnected;
        }
    }
}