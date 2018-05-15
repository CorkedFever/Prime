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
	public partial class PageFilmConsumables : ContentPage
	{
        public List<Equipment> FilmEquipments;
		public PageFilmConsumables ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            try
            {
                List<Equipment> FilmConsumables = App.repo.GetFilmConsumables();
                FilmEquipments = FilmConsumables;
                FilmListView.ItemsSource = FilmEquipments;
            }
            catch (Exception ex)
            {

                DisplayAlert("Error", ex.ToString(), "Ok");
            }

            base.OnAppearing();
        }
        public void NewFilm_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageNewEquipment());
        }
        public void txbFilmEquipmentSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txbFilmEquipmentSearch.Text;
            List<Equipment> newEquipments = FilmEquipments.FindAll(x => x.SerialNumber.StartsWith(query));
            if (!string.IsNullOrEmpty(query))
            {
                FilmListView.ItemsSource = null;
                FilmListView.ItemsSource = newEquipments;

            }
            else
            {
                FilmListView.ItemsSource = null;
                FilmListView.ItemsSource = FilmEquipments;
            }
        }
        public void FilmListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Equipment equipment = (Equipment)e.SelectedItem;
            Navigation.PushAsync(new PageEquipmentEdit(equipment));
        }
    }
}