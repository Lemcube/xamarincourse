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

namespace Course.AndroidService.Droid
{
    public class AndroidServiceManager : IServiceManager
    {

        public event Action<String> EventFromService;

        Activity _act = null;

        private static AndroidServiceManager _instance = null;
        public static  AndroidServiceManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public static void Create(Activity act)
        {
            _instance = new AndroidServiceManager(act);
        }


        private AndroidServiceManager(Activity act)
        {
            _act = act;
        }
         

        public void StartService()
        { 
            var intent = new Intent(_act, typeof(AndroidService));
            intent.PutExtra("LoopCount", 7);

            _act.StartService(intent);
        }

        public void StopService()
        {
            var intent = new Intent(_act, typeof(AndroidService));
            _act.StopService(intent);
        }

        internal void NotifyEvent(string v)
        {
            if (EventFromService != null)
            {
                EventFromService(v);
            }
        }
    }
}