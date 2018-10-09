using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Course.AndroidService
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            App.ServiceManager.EventFromService += ServiceManager_EventFromService;
        }

        private void ServiceManager_EventFromService(string obj)
        {
            Device.BeginInvokeOnMainThread(() => {
                LabelNotifica.Text = obj;
            });
        }

        private void STARTButton_Clicked(object sender, EventArgs e)
        {
            App.ServiceManager.StartService();
        }
    }
}
