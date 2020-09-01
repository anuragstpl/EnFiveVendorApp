using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.Model;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using EnFiveSales.View.Store;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Json;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.Linq;

namespace EnFiveSales.ViewModel
{
    public class AddProductViewModel : ProductViewModel
    {
        public Command AddProductCommand { get; set; }

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

        public AddProductViewModel(int receiptID)
        {
            GlobalRecieptID = receiptID;
            this.AddProductCommand = new Command(this.AddProductClicked);
        }

        private async void AddProductClicked(object obj)
        {
            AddProductRequest addProductRequest = new AddProductRequest();
            addProductRequest.AuthToken = SessionHelper.AccessToken;
            ProductDTO productDTO = new ProductDTO();
            productDTO.AddedOn = DateTime.Now.ToString();
            productDTO.IsAvailable = true;
            productDTO.Name = Name;
            productDTO.Price = Price;
            productDTO.ProductID = ProductID;
            productDTO.RecieptID = GlobalRecieptID;
            productDTO.Quantity = Quantity;
            productDTO.UpdatedOn = DateTime.Now.ToString();
            addProductRequest.productDTO = productDTO;
            JsonValue AddProductResponse = await HttpRequestHelper<AddProductRequest>.POSTreq(ServiceTypes.AddProduct, addProductRequest);
            AddProductResponce addProductResponce = JsonConvert.DeserializeObject<AddProductResponce>(AddProductResponse.ToString());
            if (addProductResponce.IsSuccess)
            {
                var mdp = (Application.Current.MainPage as MasterDetailPage);
                var navPage = mdp.Detail as NavigationPage;
                await navPage.PushAsync(new ProductList(Convert.ToInt32(GlobalRecieptID)), true);
            }
          
        }
    }
}
