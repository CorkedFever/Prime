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
	public partial class PageEquipmentEdit : ContentPage
	{
        public Equipment LoadedEquipment;
		public PageEquipmentEdit ()
		{
			InitializeComponent ();
		}
        public PageEquipmentEdit(Equipment equipment)
        {
            InitializeComponent();
            LoadedEquipment = equipment;
            RefreshDisplay();
        }
        public void RefreshDisplay()
        {
            //Add label display data here.
            txbSerialNumber.Text = LoadedEquipment.SerialNumber;
            txbDescription.Text = LoadedEquipment.Description;
            txbRIGNumber.Text = LoadedEquipment.RIGNumber;
            txbRadiographer.Text = LoadedEquipment.Radiographers;
            pckEquipmentType.SelectedItem = LoadedEquipment.EquipmentType;
            txbQuanity.Text = LoadedEquipment.Quanity.ToString();
            txbCost.Text = LoadedEquipment.Cost.ToString();
        }
        public void btnUpdate_Clicked(object sender, EventArgs e)
        {
            Equipment UpdateEquipment = LoadedEquipment;
            UpdateEquipment.SerialNumber = txbSerialNumber.Text;
            UpdateEquipment.Description = txbDescription.Text;
            UpdateEquipment.RIGNumber = txbRIGNumber.Text;
            UpdateEquipment.Radiographers = txbRadiographer.Text;
            UpdateEquipment.EquipmentType = pckEquipmentType.SelectedItem.ToString();
            UpdateEquipment.Quanity = Convert.ToInt32(txbQuanity.Text);
            UpdateEquipment.Cost = Convert.ToDouble(txbCost.Text);
            UpdateEquipment.Save();
        }
	}
}