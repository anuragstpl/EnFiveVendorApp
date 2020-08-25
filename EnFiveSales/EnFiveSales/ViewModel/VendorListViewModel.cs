using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.SaleEntities;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Json;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class VendorListViewModel : BaseViewModel
    {
        public ObservableCollection<UserDTO> UserDetails { get; set; }

        public VendorListViewModel()
        {
            Task.Run(async () => { await GetVendorData(); }).Wait();
            this.SendRecieptCommand = new Command(this.SendRecieptClicked);

        }

        public Command SendRecieptCommand { get; set; }
        
        public async Task<StoreEntity> GetVendorData()
        {
            JsonValue GetAllStoreUser = await HttpRequestHelper<String>.GetRequest(ServiceTypes.GetAllUsers, SessionHelper.AccessToken);
            StoreEntity AllstoreUserEntity = JsonConvert.DeserializeObject<StoreEntity>(GetAllStoreUser.ToString());
            if (AllstoreUserEntity.IsSuccess)
            {
                List<UserDTO> lstAllStore = AllstoreUserEntity.lstUserDetails.Select(dc => new UserDTO()
                {
                    StoreUserId = dc.StoreUserId,
                    StoreName = dc.StoreName,
                    Username = dc.Username,
                    Address = dc.Address,
                    Active = dc.Active,
                    DeviceId = dc.DeviceId,
                    Email = dc.Email,
                }).ToList();

                UserDetails = new ObservableCollection<UserDTO>();

                foreach (UserDTO getProduct in lstAllStore)
                {
                    UserDetails.Add(getProduct);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", AllstoreUserEntity.Message, "Ok");
            }
            return AllstoreUserEntity;
        }

        private async void SendRecieptClicked(object obj)
        {
            AddOrderRecieptRequest addOrderRecieptRequest = new AddOrderRecieptRequest();
            addOrderRecieptRequest.AuthToken =SessionHelper.AccessToken;
            addOrderRecieptRequest.OrderTime = DateTime.Now.ToString();
            addOrderRecieptRequest.ReceiverStoreId = 30;
            addOrderRecieptRequest.RecieptId = 47;
            addOrderRecieptRequest.SenderStoreId = 29;
           
            JsonValue addOrderRecieptResponse = await HttpRequestHelper<AddOrderRecieptRequest>.POSTreq(ServiceTypes.AddOrderReciept, addOrderRecieptRequest);
            AddOrderRecieptResponce addOrderRecieptResponce = JsonConvert.DeserializeObject<AddOrderRecieptResponce>(addOrderRecieptResponse.ToString());
            if (addOrderRecieptResponce.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Success", addOrderRecieptResponce.Message, "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", addOrderRecieptResponce.Message, "Ok");
            }
        }
    }
}