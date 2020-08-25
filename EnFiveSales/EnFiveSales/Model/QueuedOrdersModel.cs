using EnFiveSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.Model
{
   public class QueuedOrdersModel :BaseViewModel 
    {
        private string createdOn { get; set; }
        private string name { get; set; }
        private string status { get; set; }
        private string price { get; set; }
        private long recieptID { get; set; }
        private long storeID { get; set; }
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

    }
}
