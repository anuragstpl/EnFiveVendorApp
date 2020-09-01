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
    public class QueuedOrderProductsViewModal : QueuedOrderProductsModal
    {
        public Command SendQuoteCommand { get; set; }
        public Command UpdateQuoteCommand { get; set; }
        public QueuedOrderProductsViewModal(int receiptID)
        {
            RecieptID = receiptID;
            ListGetProduct = new List<QueuedOrderProductsModal>();
            ProductData = new ObservableCollection<QueuedOrderProductsModal>();
            SendQuoteCommand = new Command(this.SendQuoteClicked);
            UpdateQuoteCommand = new Command(this.UpdateQuoteClicked);
            Task.Run(async () => { await GetProduct(receiptID); }).Wait();
        }

        private async void SendQuoteClicked()
        {
            RecieptDTO recieptDTO = new RecieptDTO();
            recieptDTO.Status = "2";
            recieptDTO.Price = "";
            recieptDTO.StoreID = 0;
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

        private async void UpdateQuoteClicked()
        {
            UpdateProductAvailabilityRequest updateProductAvailabilityRequest = new UpdateProductAvailabilityRequest();
            updateProductAvailabilityRequest.ProductInfo = new List<ProductDTO>();
            updateProductAvailabilityRequest.AuthToken = SessionHelper.AccessToken;
            foreach (QueuedOrderProductsModal item in ListGetProduct)
            {
                ProductDTO productDTO = new ProductDTO();
                productDTO.AddedOn = DateTime.Now.ToString();
                productDTO.IsAvailable = true;
                productDTO.Name = item.Name;
                productDTO.Price = item.Price;
                productDTO.ProductID = item.ProductID;
                productDTO.RecieptID = item.RecieptID;
                productDTO.Quantity = item.Quantity;
                productDTO.UpdatedOn = DateTime.Now.ToString();
                updateProductAvailabilityRequest.ProductInfo.Add(productDTO);
            }
            JsonValue AddProductResponse = await HttpRequestHelper<UpdateProductAvailabilityRequest>.POSTreq(ServiceTypes.UpdateProductAvailability, updateProductAvailabilityRequest);
            UpdateProductAvailabilityResponse updateProductAvailabilityResponse = JsonConvert.DeserializeObject<UpdateProductAvailabilityResponse>(AddProductResponse.ToString());
            if (updateProductAvailabilityResponse.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", updateProductAvailabilityResponse.Message, "Ok");
            }
        }

        private async Task<AddProductResponce> GetProduct(int receiptID)
        {
            JsonValue GetProductResponce = await HttpRequestHelper<String>.GetRequest(ServiceTypes.GetProducts, SessionHelper.AccessToken + "/" + receiptID);
            AddProductResponce getProductResponse = JsonConvert.DeserializeObject<AddProductResponce>(GetProductResponce.ToString());
            if (getProductResponse.IsSuccess)
            {
                ListGetProduct = getProductResponse.Lstproducts.Select(dc => new QueuedOrderProductsModal()
                {
                    AddedOn = dc.AddedOn,
                    IsAvailable = dc.IsAvailable,
                    Name = dc.Name,
                    Price = dc.Price,
                    ProductID = dc.ProductID,
                    Quantity = dc.Quantity,
                    RecieptID = dc.RecieptID,
                    UpdatedOn = dc.UpdatedOn,
                    Total = 0
                }).ToList();

                foreach (QueuedOrderProductsModal getProduct in lstGetProduct)
                {
                    ProductData.Add(getProduct);
                }
            }
            else
            {
            }
            return getProductResponse;
        }

    }
}
