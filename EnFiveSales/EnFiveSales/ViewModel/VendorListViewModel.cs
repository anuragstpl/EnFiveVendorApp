using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.Model;
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
    public class VendorListViewModel : AvailableVendorModel
    {
        public ObservableCollection<AvailableVendorModel> UserDetails { get; set; }
        public Command SendRecieptCommand { get; set; }
        public Command SelectedVendorCommand { get; set; }
        private int globalRecieptID { get; set; }

        public int GlobalRecieptID
        {
            get { return this.globalRecieptID; }
            set
            {
                if (this.globalRecieptID == value)
                {
                    return;
                }

                this.globalRecieptID = value;
                this.NotifyPropertyChanged();
            }
        }

        private List<int> listReceiversID { get; set; }

        public List<int> ListReceiversID
        {
            get { return this.listReceiversID; }
            set
            {
                if (this.listReceiversID == value)
                {
                    return;
                }

                this.listReceiversID = value;
                this.NotifyPropertyChanged();
            }
        }

        public VendorListViewModel()
        {
            Task.Run(async () => { await GetVendorData(); }).Wait();
            this.SendRecieptCommand = new Command(this.SendRecieptClicked);
        }

        public VendorListViewModel(int receiptID)
        {
            GlobalRecieptID = receiptID;
            Task.Run(async () => { await GetVendorData(); }).Wait();
            this.SendRecieptCommand = new Command(this.SendRecieptClicked);
            this.SelectedVendorCommand = new Command(this.SelectedVendorClicked);
            ListReceiversID = new List<int>();
        }

        public async Task<StoreEntity> GetVendorData()
        {
            JsonValue GetAllStoreUser = await HttpRequestHelper<String>.GetRequest(ServiceTypes.GetAllUsers, SessionHelper.AccessToken);
            StoreEntity AllstoreUserEntity = JsonConvert.DeserializeObject<StoreEntity>(GetAllStoreUser.ToString());
            if (AllstoreUserEntity.IsSuccess)
            {
                List<AvailableVendorModel> lstAllStore = AllstoreUserEntity.lstUserDetails.Select(dc => new AvailableVendorModel()
                {
                    StoreUserId = dc.StoreUserId,
                    StoreName = dc.StoreName,
                    Username = dc.Username,
                    Address = dc.Address,
                    Active = false,
                    DeviceId = dc.DeviceId,
                    Email = dc.Email,
                    BackgroundColor = "White"
                }).ToList();

                UserDetails = new ObservableCollection<AvailableVendorModel>();

                foreach (AvailableVendorModel getProduct in lstAllStore)
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
            addOrderRecieptRequest.AuthToken = SessionHelper.AccessToken;
            addOrderRecieptRequest.ListReceiverStoreIDs = ListReceiversID;
            addOrderRecieptRequest.OrderTime = DateTime.Now.ToString();
            addOrderRecieptRequest.ReceiverStoreId = 30;
            addOrderRecieptRequest.RecieptId = GlobalRecieptID;
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

        public void SelectedVendorClicked(object obj)
        {
            AvailableVendorModel userModel = (AvailableVendorModel)obj;
            if (userModel.Active)
            {
                userModel.Active = false;
                ListReceiversID.Remove(Convert.ToInt32(userModel.StoreUserId));
                UserDetails.Where(x => x.StoreUserId == userModel.StoreUserId).FirstOrDefault().BackgroundColor = "White";
            }
            else
            {
                userModel.Active = true;
                ListReceiversID.Add(Convert.ToInt32(userModel.StoreUserId));
                UserDetails.Where(x => x.StoreUserId == userModel.StoreUserId).FirstOrDefault().BackgroundColor = "#A2CBE0";
            }
        }
    }
}