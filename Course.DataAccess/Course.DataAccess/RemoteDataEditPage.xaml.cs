using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.DataAccess.DataAccess;
using OggettiCondivisi;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Course.DataAccess
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RemoteDataEditPage : ContentPage
	{
        ServerDataItem _item = null;
        WebApiProxy _webApiProxy = null;

        public RemoteDataEditPage ()
		{
			InitializeComponent ();
            _webApiProxy = new WebApiProxy();
		}

        protected override void OnAppearing()
        {
            List<string> listItems = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                listItems.Add("Elemento" + i);
            }

            this.EntryPicker.ItemsSource = listItems;


            this.EntryName.Text = null; 
            this.EntryDescription.Text = null;

            if (_item != null)
            {
                Title = _item.Name;
                this.EntryName.Text = _item.Name;
                this.EntryDescription.Text = _item.Description;
                this.EntryDate.Date = _item.DataElemento;
            }
            else
            {
                Title = "NUOVO";
            }
        }

        internal void SetData(ServerDataItem item)
        {
            _item = item;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var name = this.EntryName.Text;
                var desc = this.EntryDescription.Text;
                var dataOra = this.EntryDate.Date;
                 
                if (_item != null)
                {
                    ServerDataItem s = new ServerDataItem()
                    {
                        Id = _item.Id,
                        Name = name,
                        Description = desc,
                        DataElemento = dataOra,
                    };

                    await _webApiProxy.Update(s);

                    await Navigation.PopAsync();
                }
                else
                {
                    // CREA NUOVO

                    ServerDataItem s = new ServerDataItem()
                    {
                        // Id = _item.Id,
                        Name = name,
                        Description = desc,
                        DataElemento = dataOra,
                    };

                    await _webApiProxy.Create(s);

                    await Navigation.PopAsync();
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("ERRORE", ex.Message, "OK");
            }         
        }
    }
}