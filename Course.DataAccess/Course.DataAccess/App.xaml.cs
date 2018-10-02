using Course.DataAccess.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Course.DataAccess
{
    public partial class App : Application
    {
        public static INetworkMonitor NetwokMonitor { get; set; }
        public static string DATA_DIR { get; set; }

        public App()
        {
            InitializeComponent();

            // DATI LOCALI
            // MainPage = new NavigationPage(new MainPage());

            // DATI DA WEBSERVICE REST
            MainPage = new NavigationPage(new MainRemoteDataPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
