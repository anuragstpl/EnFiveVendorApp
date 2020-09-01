using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using EnFiveSales.View.Store;
using EnFiveSales.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Json;
using System.Text;
using Xamarin.Forms;

namespace EnFiveSales.Model
{
   public class QueuedOrderProductsModal :BaseViewModel 
    {
        

        private long subTotal { get; set; }
        public long SubTotal
        {
            get { return this.subTotal; }
            set
            {
                if (this.subTotal == value)
                {
                    return;
                }
                this.subTotal = value;
                this.NotifyPropertyChanged();
            }
        }

        private string addedOn { get; set; }
        public string AddedOn
        {
            get { return this.addedOn; }
            set
            {
                if (this.addedOn == value)
                {
                    return;
                }

                this.addedOn = value;
                this.NotifyPropertyChanged();
            }
        }

        private bool? isAvailable { get; set; }
        public bool? IsAvailable
        {
            get { return this.isAvailable; }
            set
            {
                if (this.isAvailable == value)
                {
                    return;
                }

                this.isAvailable = value;
                this.NotifyPropertyChanged();
            }
        }

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
                this.UpdatePricing(value);
            }
        }

        public ObservableCollection<QueuedOrderProductsModal> productData { get; set; }
        public ObservableCollection<QueuedOrderProductsModal> ProductData
        {
            get { return this.productData; }
            set
            {
                if (this.productData == value)
                {
                    return;
                }
                this.productData = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<QueuedOrderProductsModal> lstGetProduct { get; set; }
        public List<QueuedOrderProductsModal> ListGetProduct
        {
            get { return this.lstGetProduct; }
            set
            {
                if (this.lstGetProduct == value)
                {
                    return;
                }
                this.lstGetProduct = value;
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

        
        private string updatedOn { get; set; }

        public string UpdatedOn
        {
            get { return this.updatedOn; }
            set
            {
                if (this.updatedOn == value)
                {
                    return;
                }

                this.updatedOn = value;
                this.NotifyPropertyChanged();
            }
        }

        private double total { get; set; }

        public double Total
        {
            get { return this.total; }
            set
            {
                if (this.total == value)
                {
                    return;
                }

                this.total = value;
                this.NotifyPropertyChanged();
            }
        }

        public  void UpdatePricing(string price)
        {
            Total =  Convert.ToDouble(Quantity) * (String.IsNullOrEmpty(price) ? 0 : Convert.ToDouble(price));
           
        }
    }
}
