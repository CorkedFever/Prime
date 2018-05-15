using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prime
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            var assembly = typeof(MainPage);
            imgLogo.Source = ImageSource.FromResource("Prime.Assets.Images.head_logo.png", assembly);
		}
        public void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenu());
        }
        protected override void OnAppearing()
        {
            
            base.OnAppearing();
        }

    }
}
