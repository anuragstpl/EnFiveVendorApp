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
    class ConfirmOrdersStoreViewModal : ConfirmOrderProductForStoreModal
    {
        public ObservableCollection<ConfirmOrderProductForStoreModal> ConfirmOrderProductsForStoreData { get; set; }
        public ConfirmOrdersStoreViewModal()
        {
            Task.Run(async () => { await ConfirmOrderProductsListForCustomer(); }).Wait();
        }
        private async Task<ConfirmOrderProductsForStoreResponce> ConfirmOrderProductsListForCustomer()
        {
            GetConfiredProductForStoreRequest getConfiredProductForStoreRequest = new GetConfiredProductForStoreRequest();
            getConfiredProductForStoreRequest.AuthToken = "130ebdc006aa4088b0ab3106c67eea52";   //SessionHelper.AccessToken;
            getConfiredProductForStoreRequest.RecieptId = 45;
            getConfiredProductForStoreRequest.StoreId = 29;
            JsonValue GetConfirmOrderProductForStoreResponse = await HttpRequestHelper<GetConfiredProductForStoreRequest>.POSTreq(ServiceTypes.GetConfirmedProductsForStore, getConfiredProductForStoreRequest);
            ConfirmOrderProductsForStoreResponce confirmOrderProductsForStoreResponce = JsonConvert.DeserializeObject<ConfirmOrderProductsForStoreResponce>(GetConfirmOrderProductForStoreResponse.ToString());
            if (confirmOrderProductsForStoreResponce.IsSuccess)
            {
                try
                {
                    //List<ConfirmOrderProductForStoreModal> lstGetReciepts = confirmOrderProductsForStoreResponce.LstProducts.Select(dc => new ConfirmOrderProductForStoreModal()
                    //{
                    //    AddedOn = dc.AddedOn,
                    //    CreatedOn = dc.CreatedOn,
                    //    IsAvailable = dc.IsAvailable,
                    //    Name = dc.Name,
                    //    OrderCandidateID = dc.OrderCandidateId,
                    //    OrderTime = dc.OrderTime,
                    //    Price = dc.Price,
                    //    ProductID = dc.ProductID,
                    //    Quantity = dc.Quantity,
                    //    ReceiverStoreID = dc.ReceiverStoreId,
                    //    RecieptID = dc.RecieptID,
                    //    RecieptOrderID = dc.ReceiverStoreId,
                    //    SenderStoreID = dc.SenderStoreId,
                    //    StoreID = dc.StoreId,
                    //    SubTotal = dc.SubTotal,
                    //    UpdatedOn = dc.UpdatedOn
                    //}).ToList();


                    ConfirmOrderProductsForStoreData = new ObservableCollection<ConfirmOrderProductForStoreModal>();

                    foreach (ProductDTO getReciept in confirmOrderProductsForStoreResponce.LstProducts)
                    {
                        ConfirmOrderProductForStoreModal confirmOrderProductForStoreModal = new ConfirmOrderProductForStoreModal();

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
                        confirmOrderProductForStoreModal.SubTotal = getReciept.SubTotal;
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
