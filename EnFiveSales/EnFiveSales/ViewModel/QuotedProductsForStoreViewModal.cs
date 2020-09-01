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
    public class QuotedProductsForStoreViewModal : QuotedProductsForStoreModal
    {
        public QuotedProductsForStoreViewModal(int receiptID, int storeID)
        {
            RecieptID = receiptID;
            StoreID = storeID;
            Task.Run(async () => { await QuotedProductsForStore(receiptID, storeID); }).Wait();
            this.UpdateRecieptStatusCommand = new Command(this.UpdateRecieptStatusClicked);
        }
        public ObservableCollection<QuotedProductsForStoreModal> QuotedProductsForStoreData { get; set; }

        private async Task<GetQuotedVendorResponce> QuotedProductsForStore(int receiptID, int storeID)
        {
            GetQuotedProductsForStoreRequest getQuotedProductsForStoreRequest = new GetQuotedProductsForStoreRequest();
            getQuotedProductsForStoreRequest.AuthToken = SessionHelper.AccessToken;
            getQuotedProductsForStoreRequest.RecieptId = receiptID;
            getQuotedProductsForStoreRequest.StoreId = storeID;
            JsonValue GetQuoteRecieptResponse = await HttpRequestHelper<GetQuotedProductsForStoreRequest>.POSTreq(ServiceTypes.GetQuotedProductsForStore, getQuotedProductsForStoreRequest);
            GetQuotedVendorResponce getQuotedResponce = JsonConvert.DeserializeObject<GetQuotedVendorResponce>(GetQuoteRecieptResponse.ToString());
            if (getQuotedResponce.IsSuccess)
            { 
                List<QuotedProductsForStoreModal> lstGetReciepts = getQuotedResponce.LstProducts.Select(dc => new QuotedProductsForStoreModal()
                {
                    CreatedOn = dc.AddedOn,
                    Name = dc.Name,
                    Price = dc.Price,
                    RecieptID = (int)dc.RecieptID,
                    Quantity = dc.Quantity,
                    SubTotal = dc.SubTotal,
                    StoreName = dc.Name
                }).ToList();

                QuotedProductsForStoreData = new ObservableCollection<QuotedProductsForStoreModal>();

                foreach (QuotedProductsForStoreModal getQuoteReciept in lstGetReciepts)
                {
                    getQuoteReciept.Total = Convert.ToDouble(getQuoteReciept.Quantity) * Convert.ToDouble(getQuoteReciept.Price);
                    QuotedProductsForStoreData.Add(getQuoteReciept);
                }
            }
            else
            {
            }
            return getQuotedResponce;
        }

        private async void UpdateRecieptStatusClicked(object obj)
        {
            RecieptDTO recieptDTO = new RecieptDTO();
            recieptDTO.Status = "4";
            recieptDTO.Price = "";
            recieptDTO.StoreID = StoreID;
            recieptDTO.RecieptID = RecieptID;
            UpdateRecieptStatusRequest updateRecieptStatusRequest = new UpdateRecieptStatusRequest();
            updateRecieptStatusRequest.AuthToken = SessionHelper.AccessToken;
            updateRecieptStatusRequest.updatRrecieptDTO = recieptDTO;
            JsonValue updateRecieptRequest = await HttpRequestHelper<UpdateRecieptStatusRequest>.POSTreq(ServiceTypes.UpdateRecieptStatus, updateRecieptStatusRequest);
            UpdateRecieptStatusResponse updateRecieptStatusResponse = JsonConvert.DeserializeObject<UpdateRecieptStatusResponse>(updateRecieptRequest.ToString());
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
