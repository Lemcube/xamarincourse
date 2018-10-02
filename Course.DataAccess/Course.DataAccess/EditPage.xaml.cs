using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.DataAccess.DataAccess;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Course.DataAccess
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage : ContentPage
	{
        DbItem _item = null;

        public EditPage()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            this.EntryPicker.ItemsSource = new List<string>() {
                "UNO",
                "DUE",
                "TRE",
                "QUATTR"
            };
           

            this.EntryName.Text = null; 
            this.EntryDescription.Text = null;

            if (_item != null)
            {
                Title = _item.Name;
                this.EntryName.Text = _item.Name;
                this.EntryDescription.Text = _item.Description;
                this.EntryDate.Date = _item.EsempioData;
            }
            else
            {
                Title = "NUOVO";
            }
        }

        internal void SetData(DbItem item)
        {
            _item = item;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var name = this.EntryName.Text;
                var desc = this.EntryDescription.Text;
                var dataOra = this.EntryDate.Date;

                DbItemAsyncRepository r = new DbItemAsyncRepository();


                if (_item != null)
                {
                    r.Udate(_item.Id, name, desc, dataOra);
                    Navigation.PopAsync();
                }
                else
                {
                    r.Insert(name, desc, dataOra);
                    Navigation.PopAsync();
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("ERRORE", ex.Message, "OK");
            }         
        }

        private void EntryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}