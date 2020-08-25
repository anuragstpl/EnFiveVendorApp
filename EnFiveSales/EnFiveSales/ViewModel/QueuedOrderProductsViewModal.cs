using EnFiveSales.DTO;
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
    public class QueuedOrderProductsViewModal : BaseViewModel
    {
       
        public ObservableCollection<QueuedOrderProductsModal> ProductData { get; set; }

        public QueuedOrderProductsViewModal()
        {
            Task.Run(async () => { await GetProduct(); }).Wait();

        }
        private async Task<AddProductResponce> GetProduct()
        {
            JsonValue GetProductResponce = await HttpRequestHelper<String>.GetRequest(ServiceTypes.GetProducts, SessionHelper.AccessToken + "/" + "45");
            AddProductResponce getProductResponse = JsonConvert.DeserializeObject<AddProductResponce>(GetProductResponce.ToString());
            if (getProductResponse.IsSuccess)
            {
                List<QueuedOrderProductsModal> lstGetProduct = getProductResponse.Lstproducts.Select(dc => new QueuedOrderProductsModal()
                {
                    AddedOn = dc.AddedOn,
                    IsAvailable = dc.IsAvailable,
                    Name = dc.Name,
                    Price = dc.Price,
                    ProductID = dc.ProductID,
                    Quantity = dc.Quantity,
                    RecieptID = dc.RecieptID,
                    UpdatedOn = dc.UpdatedOn,
                }).ToList();

                ProductData = new ObservableCollection<QueuedOrderProductsModal>();

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
