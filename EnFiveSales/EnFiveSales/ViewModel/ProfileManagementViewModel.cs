using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.Model;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using EnFiveSales.View;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EnFiveSales.ViewModel
{
    public class ProfileManagementViewModel : UserModel
    {
        public ProfileManagementViewModel()
        {
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.OpenCategoriesCommand = new Command(this.OpenCategoriesClicked);
            Username = new BaseViewModel();
            Password = new BaseViewModel();
            Address = new BaseViewModel();
            Email = new BaseViewModel();
            StoreName = new BaseViewModel();
            ConfirmPassword = new BaseViewModel();
            SelectedCategories = new BaseViewModel();
            PhoneNo = new BaseViewModel();

            MessagingCenter.Subscribe<CategoryDTO>(this, "Update", (category) =>
            {
                SelectedCategories.Data = String.Join(",", SaleItemGlobal.selectedCategories.Where(x => x.IsChecked == true).Select(x => x.Name).ToList());
            });

            Task.Run(async () => { await GetProfileData(); }).Wait();

        }

        private async Task<GetStoreProfileResponse> GetProfileData()
        {
            JsonValue getStoreProfileResponse = await HttpRequestHelper<string>.GetRequest(ServiceTypes.GetStoreProfile, SessionHelper.AccessToken);
            GetStoreProfileResponse getStoreResponse = JsonConvert.DeserializeObject<GetStoreProfileResponse>(getStoreProfileResponse.ToString());
            if (getStoreResponse.IsSuccess)
            {
                Username.Data = getStoreResponse.userDetails.Username;
                Password.Data = getStoreResponse.userDetails.Password;
                Address.Data = getStoreResponse.userDetails.Address;
                Email.Data = getStoreResponse.userDetails.Email;
                StoreName.Data = getStoreResponse.userDetails.StoreName;
                ConfirmPassword.Data = getStoreResponse.userDetails.Password;
                PhoneNo.Data = getStoreResponse.userDetails.PhoneNo;
                SaleItemGlobal.selectedCategories = getStoreResponse.userDetails.Categories;
                SelectedCategories.Data = String.Join(",", SaleItemGlobal.selectedCategories.Where(x => x.IsChecked == true).Select(x => x.Name).ToList());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", getStoreResponse.Message, "Ok");
            }
            return getStoreResponse;
        }

        private void OpenCategoriesClicked(object obj)
        {
            PopupNavigation.PushAsync(new CategorySelector());
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
                userDTO.PhoneNo = PhoneNo.Data;
                userDTO.Username = Username.Data;
                RegisterStoreRequest registerStoreRequest = new RegisterStoreRequest();
                registerStoreRequest.AuthToken = SessionHelper.AccessToken;
                registerStoreRequest.UserInfo = userDTO;
                registerStoreRequest.CategoryIDs = SaleItemGlobal.selectedCategories.Where(x => x.IsChecked == true).Select(x => x.CategoryId).ToList();
                JsonValue userLoginResponse = await HttpRequestHelper<RegisterStoreRequest>.POSTreq(ServiceTypes.UpdateStore, registerStoreRequest);
                RegisterStoreResponse registerStoreResponse = JsonConvert.DeserializeObject<RegisterStoreResponse>(userLoginResponse.ToString());
                if (registerStoreResponse.IsSuccess)
                {
                    SaleItemGlobal.selectedCategories = new List<CategoryDTO>();
                    await App.Current.MainPage.DisplayAlert("Success", registerStoreResponse.Message, "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", registerStoreResponse.Message, "Ok");
                }
            }
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
