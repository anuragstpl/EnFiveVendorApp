using EnFiveSales.Helper;
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
            MainPage = new Login();
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

        public void UpdateMainPage()
        {
            MainPage = new MasterDetailPage()
            {
                Master = new MasterNavigation() { Title = "List Management" },
                Detail = new NavigationPage(new ListManagement())
            };
        }

        public void GoToLoginPage()
        {
            MainPage = new Login();
        }

        public void GoToForgetPassPage()
        {
            MainPage = new ForgetPassword();
        }

        public static Page GetMainPage()
        {
            Page mainPage = new Page();

            if (String.IsNullOrEmpty(SessionHelper.AccessToken))
            {
                SessionHelper.ClearEverything();
                mainPage = new Login();
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ((App)App.Current).UpdateMainPage();
                });
            }
            return mainPage;
        }
    }
}
