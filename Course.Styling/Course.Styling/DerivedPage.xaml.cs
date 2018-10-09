using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Course.Styling
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DerivedPage : MyBasePage
    {
		public DerivedPage ()
		{

			InitializeComponent ();
             
            contentView.Clicked += ContentView_Clicked;
        }

        private void ContentView_Clicked()
        {
            DisplayAlert("", "CLICKED", "OK");
        }
    }
}