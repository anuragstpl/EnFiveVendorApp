using EnFiveSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.Model
{
   public  class ConfirmOrderProductsModal : BaseViewModel 
    {
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

        private long? recieptID { get; set; }

        public long? RecieptID
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
        private string status { get; set; }

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
        private string storeName { get; set; }
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
        private string username { get; set; }
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
