using EnFiveSales.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EnFiveSales.Model;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.DTO;
using System.Json;
using EnFiveSales.Helper;
using EnFiveSales.SaleEntities.Response;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    public class RegisterViewModel : UserModel
    {
        public RegisterViewModel()
        {
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.LoginCommand = new Command(this.LoginClicked);
            Username = new BaseViewModel();
            Password = new BaseViewModel();
            Address = new BaseViewModel();
            Email = new BaseViewModel();
            StoreName = new BaseViewModel();
            ConfirmPassword = new BaseViewModel();
        }

        private async void SignUpClicked(object obj)
        {
            if (CheckValidation() == 0)
            {
                UserDTO userDTO = new UserDTO();
                userDTO.Active = true;
                userDTO.Address = Address.Data;
                userDTO.DeviceId = "";
                userDTO.Email = Email.Data;
                userDTO.Password = Password.Data;
                userDTO.StoreName = StoreName.Data;
                userDTO.StoreUserId = 1;
                userDTO.Username = Username.Data;
                RegisterStoreRequest registerStoreRequest = new RegisterStoreRequest();
                registerStoreRequest.AuthToken = "";
                registerStoreRequest.UserInfo = userDTO;
                JsonValue userLoginResponse = await HttpRequestHelper<RegisterStoreRequest>.POSTreq(ServiceTypes.RegisterStore, registerStoreRequest);
                RegisterStoreResponse registerStoreResponse = JsonConvert.DeserializeObject<RegisterStoreResponse>(userLoginResponse.ToString());
                if (registerStoreResponse.IsSuccess)
                {
                    await App.Current.MainPage.DisplayAlert("Success", registerStoreResponse.Message, "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", registerStoreResponse.Message, "Ok");
                }
            }
        }

        private void LoginClicked(object obj)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new Login());
            });
        }

        public int CheckValidation()
        {
            int errorCounter = 0;
            Password.NotValidMessageError = "Password is required";
            Password.IsNotValid = string.IsNullOrEmpty(Password.Data);
            ConfirmPassword.NotValidMessageError = "Confirm Password is required";
            ConfirmPassword.IsNotValid = string.IsNullOrEmpty(ConfirmPassword.Data);
            if (!ConfirmPassword.IsNotValid)
            {
                ConfirmPassword.NotValidMessageError = "Confirm Password and Password didn't matched.";
                ConfirmPassword.IsNotValid = !ConfirmPassword.Data.Equals(Password.Data);
            }
            Email.NotValidMessageError = "Email is required";
            Email.IsNotValid = string.IsNullOrEmpty(Email.Data);
            var regex = new Regex(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");

            if (!Email.IsNotValid)
            {
                Email.NotValidMessageError = "Email format is not valid";
                Email.IsNotValid = !regex.IsMatch(Email.Data);
            }
            Username.NotValidMessageError = "Username is required";
            Username.IsNotValid = string.IsNullOrEmpty(Username.Data);
            Address.NotValidMessageError = "Address is required";
            Address.IsNotValid = string.IsNullOrEmpty(Address.Data);
            StoreName.NotValidMessageError = "Name of Store is required";
            StoreName.IsNotValid = string.IsNullOrEmpty(StoreName.Data);

            if (StoreName.IsNotValid)
            {
                errorCounter++;
                BorderColor = "Red";
            }

            if (Email.IsNotValid)
            {
                errorCounter++;
                BorderColor = "Red";
            }

            if (ConfirmPassword.IsNotValid)
            {
                errorCounter++;
                BorderColor = "Red";
            }

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

            if (Address.IsNotValid)
            {
                errorCounter++;
                BorderColor = "Red";
            }

            return errorCounter;
        }

    }
}
