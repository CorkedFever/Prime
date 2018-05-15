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
	public partial class PageEquipment : ContentPage
	{
        public List<Equipment> Equipments;
		public PageEquipment ()
		{
			InitializeComponent ();
            
            
		}
        protected override void OnAppearing()
        {

            base.OnAppearing();
            try
            {

                List<Equipment> equipments = App.repo.GetEquipments();
                Equipments = equipments;
                EquipmentListView.ItemsSource = equipments;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.ToString(), "Ok");
            }
        }
        public void btnNewEquipmentTool_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageNewEquipment());
        }
        public void DebugEquipment_Clicked(object sender, EventArgs e)
        {
            //lblFullPath.Text = App.repo.fullPath;
        }
        //public void btnEquipmentSearch_Clicked(object sender, EventArgs e)
        //{
        //    string query = txbEquipmentSearch.Text;
        //    List<Equipment> newEquipments = Equipments.FindAll(x => x.SerialNumber.Contains(query));
        //    if (!string.IsNullOrEmpty(query))
        //    {
        //        EquipmentListView.ItemsSource = null;
        //        EquipmentListView.ItemsSource = newEquipments;
                
        //    }
        //    else
        //    {
        //        EquipmentListView.ItemsSource = null;
        //        EquipmentListView.ItemsSource = Equipments;
        //    }
        //}
        public void txbEquipmentSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txbEquipmentSearch.Text;
            List<Equipment> newEquipments = Equipments.FindAll(x => x.SerialNumber.StartsWith(query));
            if (!string.IsNullOrEmpty(query))
            {
                EquipmentListView.ItemsSource = null;
                EquipmentListView.ItemsSource = newEquipments;

            }
            else
            {
                EquipmentListView.ItemsSource = null;
                EquipmentListView.ItemsSource = Equipments;
            }
        }
        public void OnMore(object sender, EventArgs e)
        {
            
        }
        public void EquipmentListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (e.SelectedItem == null)
            //    return;
            Equipment equipment = (Equipment)e.SelectedItem ;
            Navigation.PushAsync(new PageEquipmentEdit(equipment));
            //DisplayAlert("Alrt", equipment.SerialNumber, "ok");
        }
    }
}