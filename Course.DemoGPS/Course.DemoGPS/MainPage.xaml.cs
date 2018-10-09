using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Course.DemoGPS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
        }

        protected override void OnAppearing()
        {
            // map.MapType == MapType.Street;

            base.OnAppearing();
            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                new Position(37, -122), Distance.FromMiles(1)));
        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var position = e.Position;

            var a = position.Latitude + " " + position.Longitude + " " + position.ToString();
            LabelPositionContinous.Text = a;
        }

        private async void ButtonGetGPSPosition_Clicked(object sender, EventArgs e)
        {
            var position = await CrossGeolocator.Current.GetPositionAsync();


            var a = position.Latitude + " " + position.Longitude + " " + position.ToString();
            LabelPosition.Text = a;
        }
         
        private async void ButtonGetGPSPositionContinuousStart_Clicked(object sender, EventArgs e)
        {
           var ok = await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(10), 10, true, new Plugin.Geolocator.Abstractions.ListenerSettings() {
               // 
           });
        }

        private async void ButtonGetGPSPositionContinuousStop_Clicked(object sender, EventArgs e)
        {
            await CrossGeolocator.Current.StopListeningAsync();
        }
    }
}
