using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prime
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenu : ContentPage
	{
		public MainMenu ()
		{
			InitializeComponent ();
		}
        public void btnEquipment_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageEquipment(), true);
        }
        public void btnReorder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageReorder(), true);
        }
        public void btnRigConsumables_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageRigConsumables(), true);
        }
        public void btnFilmConsumabes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageFilmConsumables(), true);
        }
        public void btnRig_Clicked(object sender, EventArgs e)
        {

        }
        public void btnTrucks_Clicked(object sender, EventArgs e)
        {
            
        }
        public void btnStats_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageStats(), true);
        }

    }
}