using EnFiveSales.SaleEntities;
using EnFiveSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.Model
{
    public class QuotedProductsForStoreModal : BaseViewModel 
    {
        //Reciept
        private string createdOn { get; set; }
        private string addedOn { get; set; }
        private bool? isAvailable { get; set; }
        private string name { get; set; }
        private string orderTime { get; set; }
        private string orderCandidateID { get; set; }
        private string price { get; set; }
        private long productID { get; set; }
        private string quantity { get; set; }
        private long receiverStoreID { get; set; }
        private long recieptID { get; set; }
        private long recieptOrderID { get; set; }
        private long senderStoreID { get; set; }
        private string subTotal { get; set; }
        private long storeID { get; set; }
        private string updatedOn { get; set; }
        private string status { get; set; }
       
      
        private bool active { get; set; }
        private string address { get; set; }
        private string deviceId { get; set; }
        private string email { get; set; }
        private string storeName { get; set; }
        private long storeUserId { get; set; }
        private string username { get; set; }
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
        public string OrderCandidateID
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
        public long ReceiverStoreID
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
        public string UpdatedOn
        {
            get { return this.updatedOn; }
            set
            {
                if (this.updatedOn == value)
                {
                    return;
                }

                this.UpdatedOn = value;
                this.NotifyPropertyChanged();
            }
        }
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
        public long RecieptOrderID
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
        public long SenderStoreID
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
        public long StoreID
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
        public string Status
        {
            get { return this.status; }
            set
            {
                if (this.status == value)
                {
                    return;
                }

                this.status = value;
                this.NotifyPropertyChanged();
            }
        }
//user
        
     
        public bool Active
        {
            get { return this.active; }
            set
            {
                if (this.active == value)
                {
                    return;
                }

                this.active = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Address
        {
            get { return this.address; }
            set
            {
                if (this.address == value)
                {
                    return;
                }

                this.address = value;
                this.NotifyPropertyChanged();
            }
        }

        public string DeviceId
        {
            get { return this.deviceId; }
            set
            {
                if (this.deviceId == value)
                {
                    return;
                }

                this.deviceId = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (this.email == value)
                {
                    return;
                }

                this.email = value;
                this.NotifyPropertyChanged();
            }
        }

        public string StoreName
        {
            get { return this.storeName; }
            set
            {
                if (this.storeName == value)
                {
                    return;
                }

                this.storeName = value;
                this.NotifyPropertyChanged();
            }
        }

        public long StoreUserId
        {
            get { return this.storeUserId; }
            set
            {
                if (this.storeUserId == value)
                {
                    return;
                }

                this.storeUserId = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if (this.username == value)
                {
                    return;
                }

                this.username = value;
                this.NotifyPropertyChanged();
            }
        }
    }
}
