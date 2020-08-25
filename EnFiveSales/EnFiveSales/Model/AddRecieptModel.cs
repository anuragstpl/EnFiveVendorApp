using EnFiveSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EnFiveSales.Model
{
    public class AddRecieptModel : BaseViewModel
    {
        public string authToken { get; set; }
        private string createdOn { get; set; }
        private string name { get; set; }
        private string status { get; set; }
        private string price { get; set; }
        private long recieptID { get; set; }
        private long storeId { get; set; }
        public string AuthToken
        {
            get { return this.authToken; }
            set
            {
                if (this.authToken == value)
                {
                    return;
                }

                this.authToken = value;
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
        public long StoreId
        {
            get { return this.storeId; }
            set
            {
                if (this.storeId == value)
                {
                    return;
                }

                this.storeId = value;
                this.NotifyPropertyChanged();
            }
        }
        public Command AddRecieptCommand { get; set; }
        public Command AddRecieptPopUpCommand { get; set; }
        public Command SelectedRecieptCommand { get; set; }

    }
}
