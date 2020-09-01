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

namespace EnFiveSales.ViewModel
{
    public class ConfirmOrderProductsViewModal : ConfirmOrdersModel
    {

        public ObservableCollection<ConfirmOrderProductModel> ConfirmOrderProductsForStoreData { get; set; }
        public ConfirmOrderProductsViewModal(int receiptID, int storeID)
        {
            Task.Run(async () => { await ConfirmOrderProductsListForCustomer(receiptID, storeID); }).Wait();
        }

        private async Task<ConfirmOrderProductsForStoreResponce> ConfirmOrderProductsListForCustomer(int receiptID, int storeID)
        {
            GetConfiredProductForStoreRequest getConfiredProductForStoreRequest = new GetConfiredProductForStoreRequest();
            getConfiredProductForStoreRequest.AuthToken = SessionHelper.AccessToken;
            getConfiredProductForStoreRequest.RecieptId = receiptID;
            getConfiredProductForStoreRequest.StoreId = storeID;
            JsonValue GetConfirmOrderProductForStoreResponse = await HttpRequestHelper<GetConfiredProductForStoreRequest>.POSTreq(ServiceTypes.GetConfirmedProductsForStore, getConfiredProductForStoreRequest);
            ConfirmOrderProductsForStoreResponce confirmOrderProductsForStoreResponce = JsonConvert.DeserializeObject<ConfirmOrderProductsForStoreResponce>(GetConfirmOrderProductForStoreResponse.ToString());
            if (confirmOrderProductsForStoreResponce.IsSuccess)
            {
                try
                {
                    ConfirmOrderProductsForStoreData = new ObservableCollection<ConfirmOrderProductModel>();

                    foreach (ProductDTO getReciept in confirmOrderProductsForStoreResponce.LstProducts)
                    {
                        ConfirmOrderProductModel confirmOrderProductForStoreModal = new ConfirmOrderProductModel();

                        confirmOrderProductForStoreModal.AddedOn = getReciept.AddedOn;
                        confirmOrderProductForStoreModal.CreatedOn = getReciept.CreatedOn;
                        confirmOrderProductForStoreModal.IsAvailable = getReciept.IsAvailable;
                        confirmOrderProductForStoreModal.Name = getReciept.Name;
                        confirmOrderProductForStoreModal.OrderCandidateID = getReciept.OrderCandidateId;
                        confirmOrderProductForStoreModal.OrderTime = getReciept.OrderTime;
                        confirmOrderProductForStoreModal.Price = getReciept.Price;
                        confirmOrderProductForStoreModal.ProductID = getReciept.ProductID;
                        confirmOrderProductForStoreModal.Quantity = getReciept.Quantity;
                        confirmOrderProductForStoreModal.ReceiverStoreID = getReciept.ReceiverStoreId;
                        confirmOrderProductForStoreModal.RecieptID = getReciept.RecieptID;
                        confirmOrderProductForStoreModal.RecieptOrderID = getReciept.ReceiverStoreId;
                        confirmOrderProductForStoreModal.SenderStoreID = getReciept.SenderStoreId;
                        confirmOrderProductForStoreModal.StoreID = getReciept.StoreId;
                        confirmOrderProductForStoreModal.SubTotal = "Subtotal : INR " + getReciept.SubTotal;
                        confirmOrderProductForStoreModal.Total = Convert.ToDouble(getReciept.Quantity) * Convert.ToDouble(getReciept.Price);
                        confirmOrderProductForStoreModal.UpdatedOn = getReciept.UpdatedOn;
                        ConfirmOrderProductsForStoreData.Add(confirmOrderProductForStoreModal);
                    }

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
            }
            return confirmOrderProductsForStoreResponce;
        }
    }
}
