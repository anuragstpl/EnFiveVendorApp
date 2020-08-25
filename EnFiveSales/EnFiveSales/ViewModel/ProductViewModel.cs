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
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ProductViewModel : BaseViewModel
    {

        private string price { get; set; }
        public string Price
        {
            get { return this.price; }
            set
            {
                if (this.price == value)
                {
                    return;
                }

                this.price = value;
                this.NotifyPropertyChanged();
            }
        }

        private long productID { get; set; }
        public long ProductID
        {
            get { return this.productID; }
            set
            {
                if (this.productID == value)
                {
                    return;
                }

                this.productID = value;
                this.NotifyPropertyChanged();
            }
        }

        private long recieptID { get; set; }

        public long RecieptID
        {
            get { return this.recieptID; }
            set
            {
                if (this.recieptID == value)
                {
                    return;
                }

                this.recieptID = value;
                this.NotifyPropertyChanged();
            }
        }
        private string name { get; set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.NotifyPropertyChanged();
            }
        }

        private string quantity { get; set; }

        public string Quantity
        {
            get { return this.quantity; }
            set
            {
                if (this.quantity == value)
                {
                    return;
                }

                this.quantity = value;
                this.NotifyPropertyChanged();
            }
        }

        private string receiptName { get; set; }

        public string ReceiptName
        {
            get { return this.receiptName; }
            set
            {
                if (this.receiptName == value)
                {
                    return;
                }

                this.receiptName = value;
                this.NotifyPropertyChanged();
            }
        }

        public ObservableCollection<ProductDTO> ProductData { get; set; }

        private async Task<AddProductResponce> GetProduct(int RecieptID)
        {
            JsonValue GetProductResponce = await HttpRequestHelper<String>.GetRequest(ServiceTypes.GetProducts, SessionHelper.AccessToken + "/" + RecieptID.ToString());
            AddProductResponce getProductResponse = JsonConvert.DeserializeObject<AddProductResponce>(GetProductResponce.ToString());
            if (getProductResponse.IsSuccess)
            {
                List<ProductDTO> lstGetProduct = getProductResponse.Lstproducts.Select(dc => new ProductDTO()
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

                ProductData = new ObservableCollection<ProductDTO>();

                foreach (ProductDTO getProduct in lstGetProduct)
                {
                    ProductData.Add(getProduct);
                }
            }
            else
            {

            }
            return getProductResponse;
        }

        public Command AddProductCommand { get; set; }

        public Command SendProductToVendorCommand { get; set; }

        public Command AddProductPopUpCommand { get; set; }

        public ProductViewModel(int RecieptID)
        {
            Task.Run(async () => { await GetProduct(RecieptID); }).Wait();
            this.AddProductCommand = new Command(this.AddProductClicked);
            this.AddProductPopUpCommand = new Command(this.AddProductPopUpClicked);
        }

        public ProductViewModel()
        {
            this.AddProductCommand = new Command(this.AddProductClicked);
            this.AddProductPopUpCommand = new Command(this.AddProductPopUpClicked);
        }

        private async void AddProductClicked(object obj)
        {
            ///GetProducts/{AuthToken}/{RecieptID} API need to be implemented
            AddProductRequest addProductRequest = new AddProductRequest();
            addProductRequest.AuthToken = SessionHelper.AccessToken;
            ProductDTO productDTO = new ProductDTO();
            productDTO.AddedOn = DateTime.Now.ToString();
            productDTO.IsAvailable = true;
            productDTO.Name = Name;
            productDTO.Price = Price;
            productDTO.ProductID = ProductID;
            productDTO.RecieptID = 45;
            productDTO.Quantity = Quantity;
            productDTO.UpdatedOn = DateTime.Now.ToString();
            addProductRequest.productDTO = productDTO;
            JsonValue AddProductResponse = await HttpRequestHelper<AddProductRequest>.POSTreq(ServiceTypes.AddProduct, addProductRequest);
            AddProductResponce addProductResponce = JsonConvert.DeserializeObject<AddProductResponce>(AddProductResponse.ToString());
            if (addProductResponce.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("success", addProductResponce.Message, "Ok");
                Task.Run(async () => { await GetProduct(45); }).Wait();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", addProductResponce.Message, "Ok");
            }
            PopupNavigation.PopAsync(true);
        }

        private void AddProductPopUpClicked(object obj)
        {
            PopupNavigation.PushAsync(new AddProduct());
        }

    }
}
