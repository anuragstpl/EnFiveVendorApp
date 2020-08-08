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

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    public class RegisterViewModel : UserModel
    {
        public RegisterViewModel()
        {
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.LoginCommand = new Command(this.LoginClicked);
        }

        private async void SignUpClicked(object obj)
        {
            UserDTO userDTO = new UserDTO();
            userDTO.Active = true;
            userDTO.Address = Address;
            userDTO.DeviceId = "";
            userDTO.Email = Email;
            userDTO.Password = Password;
            userDTO.StoreName = StoreName;
            userDTO.StoreUserId = 1;
            userDTO.Username = Username;
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

        private async void LoginClicked(object obj)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new Login());
            });
        }

    }
}
