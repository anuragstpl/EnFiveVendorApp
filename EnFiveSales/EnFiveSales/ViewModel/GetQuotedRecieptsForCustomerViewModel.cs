using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.Model;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EnFiveSales.ViewModel
{
    public class GetQuotedRecieptsForCustomerViewModel : GetQuotedRecieptsForCustomerModel
    {
        public ObservableCollection<GetQuotedRecieptsForCustomerModel> GetQuotedRecieptsForCustomerData { get; set; }

        public GetQuotedRecieptsForCustomerViewModel()
        {
            Task.Run(async () => { await QuotedRecieptForCustomer(); }).Wait();
            this.UpdateRecieptStatusCommand = new Command(this.UpdateRecieptStatusClicked);
        }
        private async Task<GetQuotedRecieptsForCustomerResponce> QuotedRecieptForCustomer()
        {
            string AccessToken = "6a3c18078fda475fb106b38a162b4ce8";
            JsonValue GetQuotedRecieptCustResponse = await HttpRequestHelper<String>.GetRequest(ServiceTypes.GetQuotedRecieptsForCustomer, AccessToken);
            GetQuotedRecieptsForCustomerResponce getQuotedRecieptsForCustomerResponce = JsonConvert.DeserializeObject<GetQuotedRecieptsForCustomerResponce>(GetQuotedRecieptCustResponse.ToString());
            if (getQuotedRecieptsForCustomerResponce.IsSuccess)
            {
                List<GetQuotedRecieptsForCustomerModel> lstGetReciepts = getQuotedRecieptsForCustomerResponce.LstReciepts.Select(dc => new GetQuotedRecieptsForCustomerModel()
                {
                    Name = dc.Name,
                    Price = dc.Price,
                    RecieptID = dc.RecieptID,
                    Status = dc.Status,
                    StoreID = dc.StoreID,
                    StoreName = dc.StoreName,
                    Username = dc.Username
                }).ToList();

                GetQuotedRecieptsForCustomerData = new ObservableCollection<GetQuotedRecieptsForCustomerModel>();

                foreach (GetQuotedRecieptsForCustomerModel getReciept in lstGetReciepts)
                {
                    GetQuotedRecieptsForCustomerData.Add(getReciept);
                }
            }
            else
            {
            }
            return getQuotedRecieptsForCustomerResponce;
        }
        
        // Add new Button to intigrate 
        private async void UpdateRecieptStatusClicked(object obj)
        {
            RecieptDTO recieptDTO = new RecieptDTO();
            recieptDTO.Status = "4";
            recieptDTO.Price = "52000";
            recieptDTO.StoreID = 29;
            recieptDTO.RecieptID = 45;
            UpdateRecieptStatusRequest updateRecieptStatusRequest = new UpdateRecieptStatusRequest();
            updateRecieptStatusRequest.AuthToken = "6a3c18078fda475fb106b38a162b4ce8";    //SessionHelper.AccessToken;
            updateRecieptStatusRequest.updatRrecieptDTO = recieptDTO;
            JsonValue updateRecieptRequest = await HttpRequestHelper<UpdateRecieptStatusRequest>.POSTreq(ServiceTypes.UpdateRecieptStatus, updateRecieptStatusRequest);
            UpdateRecieptStatusResponse updateRecieptStatusResponse   = JsonConvert.DeserializeObject<UpdateRecieptStatusResponse>(updateRecieptRequest.ToString());
            if (updateRecieptStatusResponse.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Success", updateRecieptStatusResponse.Message, "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", updateRecieptStatusResponse.Message, "Ok");
            }
        }

    }
}
