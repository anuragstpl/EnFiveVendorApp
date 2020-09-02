﻿using EnFiveSales.Helper;
using EnFiveSales.Model;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using EnFiveSales.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    public class LoginViewModel : LoginModel
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginPageViewModel" /> class.
        /// </summary>
        public LoginViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.SocialMediaLoginCommand = new Command(this.SocialLoggedIn);
            Username = new BaseViewModel();
            Password = new BaseViewModel();
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the social media login button is clicked.
        /// </summary>
        public Command SocialMediaLoginCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void LoginClicked(object obj)
        {
            if (CheckValidation() == 0)
            {
                LoginStoreRequest loginStoreRequest = new LoginStoreRequest();
                loginStoreRequest.Username = Username.Data;
                loginStoreRequest.Password = Password.Data;
                JsonValue userLoginResponse = await HttpRequestHelper<LoginStoreRequest>.POSTreq(ServiceTypes.Login, loginStoreRequest);
                LoginStoreResponse loginStoreResponse = JsonConvert.DeserializeObject<LoginStoreResponse>(userLoginResponse.ToString());
                if (loginStoreResponse.IsSuccess)
                {
                    SessionHelper.AccessToken = loginStoreResponse.Token;
                    await SendPushToServer(SessionHelper.DeviceToken);
                    ((App)App.Current).UpdateMainPage();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", loginStoreResponse.Message, "Ok");
                }
            }
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new Register());
            });
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ForgotPasswordClicked(object obj)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new ForgetPassword());
            });
        }

        /// <summary>
        /// Invoked when social media login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SocialLoggedIn(object obj)
        {
            // Do something
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

        public int CheckValidation()
        {
            int errorCounter = 0;
            Password.NotValidMessageError = "Password is required";
            Password.IsNotValid = string.IsNullOrEmpty(Password.Data);
            Username.NotValidMessageError = "Username is required";
            Username.IsNotValid = string.IsNullOrEmpty(Username.Data);

            if (Password.IsNotValid)
            {
                errorCounter++;
                BorderColor = "Red";
            }

            if (Username.IsNotValid)
            {
                errorCounter++;
                BorderColor = "Red";
            }
            return errorCounter;
        }

        #endregion
    }
}
