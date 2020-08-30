using EnFiveSales.Helper;
using EnFiveSales.Model;
using EnFiveSales.SaleEntities.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace EnFiveSales.ViewModel
{
   public class ConfirmOrderProductsViewModal : ConfirmOrderProductsModal 
    {

        public ObservableCollection<ConfirmOrderProductsModal> ConfirmOrderProductsData { get; set; }
        public ConfirmOrderProductsViewModal()
        {
            Task.Run(async () => { await ConfirmOrderRecieptForCustomer(); }).Wait();
        }

        private async Task<ConfirmOrderProductsResponse> ConfirmOrderRecieptForCustomer()
        {
            string AccessToken = "130ebdc006aa4088b0ab3106c67eea52";
            JsonValue GetConfirmOrderProductResponse = await HttpRequestHelper<String>.GetRequest(ServiceTypes.GetConfirmedRecieptsForCustomer, AccessToken);
            ConfirmOrderProductsResponse confirmOrderProductsResponse = JsonConvert.DeserializeObject<ConfirmOrderProductsResponse>(GetConfirmOrderProductResponse.ToString());
            if (confirmOrderProductsResponse.IsSuccess)
            {
                List<ConfirmOrderProductsModal> lstGetReciepts = confirmOrderProductsResponse.LstReciepts.Select(dc => new ConfirmOrderProductsModal()
                {
                    CreatedOn = dc.CreatedOn, 
                    Name = dc.Name,
                    Price = dc.Price,
                    RecieptID = dc.RecieptID,
                    Status = dc.Status,
                    StoreID = dc.StoreID,
                    StoreName = dc.StoreName,
                    Username = dc.Username
                }).ToList();

                ConfirmOrderProductsData = new ObservableCollection<ConfirmOrderProductsModal>();

                foreach (ConfirmOrderProductsModal getReciept in lstGetReciepts)
                {
                    ConfirmOrderProductsData.Add(getReciept);
                }
            }
            else
            {
            }
            return confirmOrderProductsResponse;
        }

    }
}
