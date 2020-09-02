using EnFiveSales.DataService;
using EnFiveSales.Helper;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using EnFiveSales.View;
using EnFiveSales.View.Store;
using Newtonsoft.Json;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnFiveSales
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainThread.BeginInvokeOnMainThread(new Action(() =>
            {
                MainPage = GetMainPage();
            }));

            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
                SessionHelper.DeviceToken = p.Token;
                Task.Run(async () => { await SendPushToServer(p.Token); }).ConfigureAwait(false);
            };

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Received");
                DependencyService.Get<IMessage>().DisplayPush(GetPushMessage(p.Data.Values));
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }
            };
        }

        public async Task<UpdatePushTokenResponse> SendPushToServer(string token)
        {
            UpdatePushTokenResponse updateDeviceTokenResponse = new UpdatePushTokenResponse();
            if (!String.IsNullOrEmpty(SessionHelper.AccessToken))
            {
                UpdatePushTokenRequest updateDeviceTokenRequest = new UpdatePushTokenRequest();
                updateDeviceTokenRequest.DevicePushToken = token;
                updateDeviceTokenRequest.DeviceType = Device.RuntimePlatform;
                updateDeviceTokenRequest.AuthToken = SessionHelper.AccessToken;
                System.Json.JsonValue updateUserResponse = await HttpRequestHelper<UpdatePushTokenRequest>.POSTreq(ServiceTypes.UpdatePushToken, updateDeviceTokenRequest);
                updateDeviceTokenResponse = JsonConvert.DeserializeObject<UpdatePushTokenResponse>(updateUserResponse.ToString());
            }
            return updateDeviceTokenResponse;
        }

        public string GetPushMessage(ICollection<object> collectionMessages)
        {
            string message = "";
            foreach (string item in collectionMessages)
            {
                message = item;
            }
            return message;
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
