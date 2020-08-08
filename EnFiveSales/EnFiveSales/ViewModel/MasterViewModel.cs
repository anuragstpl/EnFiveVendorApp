using EnFiveSales.Helper;
using EnFiveSales.View;
using EnFiveSales.View.Store;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EnFiveSales.ViewModel
{
    public class MasterViewModel
    {
        public ICommand NavigationCommand
        {
            get
            {
                return new Command((value) =>
                {
                    // COMMENT: This is just quick demo code. Please don't put this in a production app.
                    var mdp = (Application.Current.MainPage as MasterDetailPage);
                    var navPage = mdp.Detail as NavigationPage;

                    // Hide the Master page
                    mdp.IsPresented = false;

                    switch (value.ToString())
                    {
                        case "1":
                            if (navPage.Navigation.NavigationStack.Count == 0 ||
                                navPage.Navigation.NavigationStack.Last().GetType() != typeof(ListManagement))
                            {
                                navPage.PushAsync(new ListManagement(), true);
                            }
                            break;
                        case "2":
                            if (navPage.Navigation.NavigationStack.Count == 0 ||
                               navPage.Navigation.NavigationStack.Last().GetType() != typeof(QueuedOrders))
                            {
                                navPage.PushAsync(new QueuedOrders(), true);
                            }
                            break;
                        case "3":
                            if (navPage.Navigation.NavigationStack.Count == 0 ||
                               navPage.Navigation.NavigationStack.Last().GetType() != typeof(ConfirmOrders))
                            {
                                navPage.PushAsync(new ConfirmOrders(), true);
                            }
                            break;
                        case "4":
                            if (navPage.Navigation.NavigationStack.Count == 0 ||
                               navPage.Navigation.NavigationStack.Last().GetType() != typeof(ProfileManagement))
                            {
                                navPage.PushAsync(new ProfileManagement(), true);
                            }
                            break;
                        case "5":
                            if (navPage.Navigation.NavigationStack.Count == 0 ||
                               navPage.Navigation.NavigationStack.Last().GetType() != typeof(Login))
                            {
                                UserLogout();
                            }
                            break;
                        case "":
                            break;
                    }

                });
            }
        }

        #region Methods

        public async void UserLogout()
        {
            //UserLogoutRequest userLogoutRequest = new UserLogoutRequest();
            //userLogoutRequest.AuthToken = SessionHelper.AccessToken;
            //System.Json.JsonValue userLogoutResponse = await ServiceRequestHelper<UserLogoutRequest>.POSJSONTreq(ServiceTypes.Logout, userLogoutRequest);
            //UserLogoutResponse userLogout = JsonConvert.DeserializeObject<UserLogoutResponse>(userLogoutResponse.ToString());
            //if (userLogout.IsSuccess)
            //{
            SessionHelper.ClearEverything();
            Device.BeginInvokeOnMainThread(() =>
            {
                ((App)App.Current).GoToLoginPage();
            });
            //}
            //else
            //{
            //    await App.Current.MainPage.DisplayAlert("Some Error Occured", userLogout.Message, "OK");
            //}
        }

        #endregion
    }
}
