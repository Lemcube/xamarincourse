using System.Threading.Tasks;

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
using Xamarin.Forms;

namespace Course.Plugins.Droid
{
    public class AndroidScanner : IBarcode
    {
        Android.App.Application _androidApplication;

        bool _stopped = false;

        public AndroidScanner(Android.App.Application androidApplication)
        {
            _androidApplication = androidApplication;
        }

        public async Task ScanAsync()
        {
            _stopped = false;

            // Initialize the scanner first so it can track the current context
            ZXing.Mobile.MobileBarcodeScanner.Initialize(_androidApplication);


            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var opt = new ZXing.Mobile.MobileBarcodeScanningOptions()
            {
                // DelayBetweenContinuousScans = 1000,
                UseNativeScanning = true,
            };

            scanner.ScanContinuously(opt, f);
            // return null;
        }

        public void f(ZXing.Result result) { 


            if (result != null)

            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var toShow = result.Text + " - " + DateTime.Now.Ticks;
                    Toast.MakeText(_androidApplication, toShow, ToastLength.Short).Show();
                    // return result.Text;
                });
            }
        }

        public void Stop()
        {
            _stopped = true;
        }
    }
}