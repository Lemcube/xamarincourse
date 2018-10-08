using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Course.Plugins
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ButtonTakePhoto_Clicked(object sender, EventArgs e)
        { 
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

           var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            { 
                Directory = "Sample",
                Name = "test.jpg",
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            PhotoImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        protected override bool OnBackButtonPressed()
        { 
            return base.OnBackButtonPressed();
        }

        private async void ButtonScanBarcode_Clicked(object sender, EventArgs e)
        {
            await Course.Plugins.App.Scanner.ScanAsync();

            // this.LabelBArcodeScaned.Text = text;
        }
    }
}
