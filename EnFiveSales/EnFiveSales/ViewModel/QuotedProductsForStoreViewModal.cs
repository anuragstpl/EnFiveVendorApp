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
   public  class QuotedProductsForStoreViewModal : BaseViewModel 
    {
        public QuotedProductsForStoreViewModal()
        {
            Task.Run(async () => { await QuotedProductsForStore(); }).Wait();
        }
        public ObservableCollection<QuotedProductsForStoreModal> QuotedProductsForStoreData { get; set; }

        private async Task<GetQuotedVendorResponce> QuotedProductsForStore()
        {
            GetQuotedProductsForStoreRequest getQuotedProductsForStoreRequest = new GetQuotedProductsForStoreRequest();
            getQuotedProductsForStoreRequest.AuthToken = "6a3c18078fda475fb106b38a162b4ce8";   //SessionHelper.AccessToken;
            getQuotedProductsForStoreRequest.RecieptId = 45;
            getQuotedProductsForStoreRequest.StoreId = 30;
            JsonValue GetQuoteRecieptResponse = await HttpRequestHelper<GetQuotedProductsForStoreRequest>.POSTreq(ServiceTypes.GetQuotedProductsForStore, getQuotedProductsForStoreRequest);
            GetQuotedVendorResponce getQuotedResponce  = JsonConvert.DeserializeObject<GetQuotedVendorResponce>(GetQuoteRecieptResponse.ToString());
            if (getQuotedResponce.IsSuccess)
            {
                //bind data in listView   
                List<QuotedProductsForStoreModal> lstGetReciepts = getQuotedResponce.LstProducts.Select(dc => new QuotedProductsForStoreModal()
                {
                    CreatedOn = dc.AddedOn,
                    Name = dc.Name,
                    Price = dc.Price,
                    RecieptID = (int)dc.RecieptID,
                   Quantity = dc.Quantity,
                  //SubTotal = dc.
                    //StoreID = (int)dc.StoreID,
                    StoreName = dc.Name    
                }).ToList();


                QuotedProductsForStoreData = new ObservableCollection<QuotedProductsForStoreModal>();

                foreach (QuotedProductsForStoreModal getQuoteReciept in lstGetReciepts)
                {
                    QuotedProductsForStoreData.Add(getQuoteReciept);
                }
            }
            else
            {
            }
            return getQuotedResponce;
        }


    }
}
