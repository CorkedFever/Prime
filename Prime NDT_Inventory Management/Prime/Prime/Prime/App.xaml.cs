using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Prime.Database;
namespace Prime
{
	public partial class App : Application
	{
        public static Repository repo;
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new Prime.MainPage());
            repo = new Repository("somepath");
		}
        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Prime.MainPage());
            repo = new Repository(databaseLocation);
        }
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
