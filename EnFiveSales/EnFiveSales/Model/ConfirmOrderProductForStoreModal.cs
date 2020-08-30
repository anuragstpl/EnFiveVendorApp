using EnFiveSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.Model
{
   public class ConfirmOrderProductForStoreModal : BaseViewModel
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
        private string createdOn { get; set; }
        public string CreatedOn
        {
            get { return this.createdOn; }
            set
            {
                if (this.createdOn == value)
                {
                    return;
                }

                this.createdOn = value;
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
        private long orderCandidateID { get; set; }
        public long OrderCandidateID
        {
            get { return this.orderCandidateID; }
            set
            {
                if (this.orderCandidateID == value)
                {
                    return;
                }

                this.orderCandidateID = value;
                this.NotifyPropertyChanged();
            }
        }
        private string orderTime { get; set; }
        public string OrderTime
        {
            get { return this.orderTime; }
            set
            {
                if (this.orderTime == value)
                {
                    return;
                }

                this.orderTime = value;
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
        private long? receiverStoreID { get; set; }
        public long? ReceiverStoreID
        {
            get { return this.receiverStoreID; }
            set
            {
                if (this.receiverStoreID == value)
                {
                    return;
                }

                this.receiverStoreID = value;
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
        private long? recieptOrderID { get; set; }
        public long? RecieptOrderID
        {
            get { return this.recieptOrderID; }
            set
            {
                if (this.recieptOrderID == value)
                {
                    return;
                }

                this.recieptOrderID = value;
                this.NotifyPropertyChanged();
            }
        }
        private long? senderStoreID { get; set; }
        public long? SenderStoreID
        {
            get { return this.senderStoreID; }
            set
            {
                if (this.senderStoreID == value)
                {
                    return;
                }

                this.senderStoreID = value;
                this.NotifyPropertyChanged();
            }
        }
        private long? storeID { get; set; }
        public long? StoreID
        {
            get { return this.storeID; }
            set
            {
                if (this.storeID == value)
                {
                    return;
                }

                this.storeID = value;
                this.NotifyPropertyChanged();
            }
        }
        private string subTotal { get; set; }
        public string SubTotal
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
