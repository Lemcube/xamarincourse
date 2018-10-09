

using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using System;
using System.Timers;

namespace Course.AndroidService.Droid
{
    [Service(Label = "Shake to launch")]
    public class AndroidService : Service
    {

        Timer _timer = null;

        public AndroidService()
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override void OnStart(Intent intent, int startId)
        {

        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            _timer = new Timer();
            _timer.Interval = 3000;
            _timer.Start();

            _timer.Elapsed += _timer_Elapsed;
             
            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            Log.Info("asdsada", "OnDestroy");
            base.OnDestroy();
        }

        public override bool StopService(Intent name)
        {
            Log.Info("asdsada", "StopService");
            return base.StopService(name);
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Log.Info("asdsada", "TIMER ELEPASED");

            AndroidServiceManager.Instance.NotifyEvent(DateTime.Now.ToString());
        }

        public override IBinder OnBind(Intent intent)
        {
            throw new System.NotImplementedException();
        }

    }

}