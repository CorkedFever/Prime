using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prime.Database;

namespace Prime
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageRigConsumables : ContentPage
    {
        public List<Equipment> RigEquipments;
        public PageRigConsumables ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            try
            {
                List<Equipment> RigConsumables = App.repo.GetRigConsumables();
                RigEquipments = RigConsumables;
                RigCListView.ItemsSource = RigEquipments;
            }
            catch (Exception ex)
            {

                DisplayAlert("Error", ex.ToString(), "Ok");
            }

            base.OnAppearing();
        }
        public void NewConsumable_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageNewEquipment());
        }
        public void txbRigEquipmentSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txbRigEquipmentSearch.Text;
            List<Equipment> newEquipments = RigEquipments.FindAll(x => x.SerialNumber.StartsWith(query));
            if (!string.IsNullOrEmpty(query))
            {
                RigCListView.ItemsSource = null;
                RigCListView.ItemsSource = newEquipments;

            }
            else
            {
                RigCListView.ItemsSource = null;
                RigCListView.ItemsSource = RigEquipments;
            }
        }
        public void RigConsumableListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Equipment equipment = (Equipment)e.SelectedItem;
            Navigation.PushAsync(new PageEquipmentEdit(equipment));
        }
    }
}