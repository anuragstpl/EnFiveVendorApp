using EnFiveSales.Helper;
using EnFiveSales.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    public class LoginViewModel : BaseViewModel
    {
        #region Fields

        private string email;

        private string password;

        #endregion

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
        }

        #endregion

        #region property

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.email == value)
                {
                    return;
                }
                this.email = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }
                this.password = value;
                this.NotifyPropertyChanged();
            }
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
            //PopupNavigation.PushAsync(new ActivityLoader());
            //UserLoginRequest userLoginRequest = new UserLoginRequest();
            //userLoginRequest.PasswordHash = Password;
            //userLoginRequest.UserNameOREmail = Email;
            //System.Json.JsonValue userLoginResponse = await ServiceRequestHelper<UserLoginRequest>.POSJSONTreq(ServiceTypes.Login, userLoginRequest);
            //UserLoginResponse userLogin = JsonConvert.DeserializeObject<UserLoginResponse>(userLoginResponse.ToString());
            //if (userLogin.IsSuccess)
            //{
            //    SessionHelper.AccessToken = userLogin.Token;
            //    SessionHelper.FullName = userLogin.FullName;
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
                    ((App)App.Current).UpdateMainPage();
            //    });
            //    PopupNavigation.PopAsync(true);
            //}
            //else
            //{
            //    PopupNavigation.PopAsync(true);
            //    await App.Current.MainPage.DisplayAlert("Incorrect Details", userLogin.Message, "OK");
            //}
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

        #endregion
    }
}
