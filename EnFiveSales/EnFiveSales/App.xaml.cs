using EnFiveSales.View;
using EnFiveSales.View.Store;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnFiveSales
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ConfirmOrderProducts();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
