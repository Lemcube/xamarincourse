using Acr.UserDialogs;
using Course.DataAccess.DataAccess;
using Newtonsoft.Json;
using OggettiCondivisi;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Course.DataAccess
{
    public partial class MainRemoteDataPage : ContentPage
    {

        WebApiProxy _webApiProxy = null;
        
        public MainRemoteDataPage()
        {

            InitializeComponent();
            _webApiProxy = new WebApiProxy();

        }
        protected override async void OnAppearing()
        {
            this.BackgroundColor = App.NetwokMonitor.IsOnline() ? Color.White : Color.Gray;

            /*
            // VERSIONE SINCONA
            DbItemRepository a = new DbItemRepository();
            var lista = a.GetAllDbItem();

            // VERSIONE SINCRONA WRAPPATA IN UNA CHIMATA ASINCRONA
            await Task.Run(() => {
                DbItemRepository b = new DbItemRepository();
                var result = a.GetAllDbItem();
            });
            */

            // VERSIONE ASINC

            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                this.IsBusy = true;

                /*
                UserDialogs.Instance.Toast(new ToastConfig("TOAST") {
                    Message = "HAI CANCELLATO",
                    Action = new ToastAction() {
                        Action = new Action(() => {
                            DisplayAlert("TITLE", "messagggio2", "OK");
                        })
                    }
                });
                */

                // UserDialogs.Instance.ShowLoading();

                ListViewElementi.ItemsSource = await _webApiProxy.GetAll();

                // var result = await DisplayActionSheet("TITLE", "CANCEL", "DISRUGGI", "UNO", "DUE", "TRE");
            }
            catch (Exception ex)
            {
                this.IsBusy = false;
                await DisplayAlert("", ex.Message, "OK");
            }
            finally
            {
                // UserDialogs.Instance.HideLoading();
                this.IsBusy = false;
            }
        }

        /// <summary>
        /// ORA è UN DELETE
        /// </summary> 
        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var bc = ((Button)sender).BindingContext;
            var item = (ServerDataItem)bc;

            await _webApiProxy.Delete(item); 

            await LoadData();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var editPage = new RemoteDataEditPage();
            editPage.SetData(new ServerDataItem());

            await Navigation.PushAsync(editPage);
        }

        private async void ListViewElementi_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (ServerDataItem)(e.Item);

            var editPage = new RemoteDataEditPage();
            editPage.SetData(item);

            await Navigation.PushAsync(editPage);
        }
    }
}
