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
	public partial class PageNewEquipment : ContentPage
	{
		public PageNewEquipment ()
		{
			InitializeComponent ();
		}
        public void btnSaveEquipment_Clicked(object sender, EventArgs e)
        {
            try
            {
                Equipment equipment = new Equipment();
                equipment.SerialNumber = txbSerialNumber.Text;
                equipment.Description = txbDescription.Text;
                equipment.RIGNumber = txbRIGNumber.Text;
                equipment.Radiographers = txbRadiographer.Text;
                equipment.EquipmentType = pckEquipmentType.SelectedItem.ToString();
                equipment.Quanity = Convert.ToInt32(txbQuanity.Text);
                equipment.Cost = Convert.ToDouble(txbCost.Text);
                equipment.Reorder = false;
                equipment.IsBroken = false;
                equipment.Save();
                //DisplayAlert("Successful", "Saving new Equipment is Successful", "Ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.ToString(), "Ok");
            }

        }
    }
}