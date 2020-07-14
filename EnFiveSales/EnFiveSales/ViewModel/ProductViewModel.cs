using EnFiveSales.DTO;
using EnFiveSales.View.Store;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ProductViewModel : BaseViewModel
    {
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

        private double quantity { get; set; }

        public double Quantity
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

        private ObservableCollection<ProductDTO> productInfo { get; set; }

        public ObservableCollection<ProductDTO> ProductInfo
        {
            get { return this.productInfo; }
            set
            {
                if (this.productInfo == value)
                {
                    return;
                }

                this.productInfo = value;
                this.NotifyPropertyChanged();
            }
        }

        public Command AddProductCommand { get; set; }

        public Command AddProductPopUpCommand { get; set; }

        public ProductViewModel()
        {
            ///GetProducts/{AuthToken}/{RecieptID} API need to be implemented
            ReceiptName = "Reciept Name";
            ProductDTO productDTO = new ProductDTO();
            productDTO.Name = "Test Product";
            productDTO.Quantity = "10.00";
            productDTO.AddedOn = DateTime.UtcNow.ToString();
            ProductInfo = new ObservableCollection<ProductDTO>();
            ProductInfo.Add(productDTO);
            this.AddProductCommand = new Command(this.AddProductClicked);
            this.AddProductPopUpCommand = new Command(this.AddProductPopUpClicked);
        }

        private void AddProductClicked(object obj)
        {
            //AddProduct API need to be implemented
            ///GetProducts/{AuthToken}/{RecieptID} API need to be implemented
            PopupNavigation.PopAsync(true);
        }

        private void AddProductPopUpClicked(object obj)
        {
            PopupNavigation.PushAsync(new AddProduct());
        }

    }
}
