using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace Course.DataAccess.Droid
{
    [Activity(Label = "Course.DataAccess", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    { 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var app = new App();
            // App.DATA_DIR = Android.OS.Environment.ExternalStorageDirectory.Path;
            App.DATA_DIR = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            App.NetwokMonitor = new AndroidNetworkMonitor();

            //UserDialogs.Init(this);
            UserDialogs.Init(() => (Activity)Forms.Context);

            LoadApplication(app);
        }
    }
}