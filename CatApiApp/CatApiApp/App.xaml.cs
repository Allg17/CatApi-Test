using CatApiApp.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatApiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            ApiHelper.InitializeClient(); 
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
