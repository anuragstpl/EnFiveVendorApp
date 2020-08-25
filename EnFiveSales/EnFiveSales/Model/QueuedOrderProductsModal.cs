using EnFiveSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.Model
{
   public class QueuedOrderProductsModal :BaseViewModel 
    {
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
    }
}
