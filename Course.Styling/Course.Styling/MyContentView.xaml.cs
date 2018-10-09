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
	public partial class MyContentView : ContentView
	{
        public event Action Clicked;

		public MyContentView ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(
               nameof(ButtonText), typeof(string), typeof(Button), string.Empty);
         
        public string ButtonText
        {
            get
            {
                return this.ButtonFromContentView.Text;
            }
            set
            {
                this.ButtonFromContentView.Text = value;
            }
        }

        private void ButtonFromContentView_Clicked(object sender, EventArgs e)
        {
            Clicked?.Invoke();
        }
    }
}