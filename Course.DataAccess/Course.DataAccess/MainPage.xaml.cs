using Course.DataAccess.DataAccess;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Course.DataAccess
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }
        protected override async void OnAppearing()
        {
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
            DbItemAsyncRepository asyncRepo = new DbItemAsyncRepository();
            var elementi = await asyncRepo.GetAllDbItemAsync();

            ListViewElementi.ItemsSource = elementi;
        }

        /// <summary>
        /// ORA è UN DELETE
        /// </summary> 
        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            var bc = ((Button)sender).BindingContext;
            var item = (DbItem)bc;

            DbItemRepository repo = new DbItemRepository();
            repo.Delete(item);

            await LoadData();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var editPage = new EditPage();
            editPage.SetData(null);

            await Navigation.PushAsync(editPage);
        }

        private async void ListViewElementi_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (DbItem)(e.Item);

            var editPage = new EditPage();
            editPage.SetData(item);

            await Navigation.PushAsync(editPage);
        }
    }
}
