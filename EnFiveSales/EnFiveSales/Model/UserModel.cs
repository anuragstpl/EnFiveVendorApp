using EnFiveSales.DTO;
using EnFiveSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace EnFiveSales.Model
{
    public class UserModel : BaseViewModel
    {
        private bool active { get; set; }
        private BaseViewModel address { get; set; }
        private string deviceId { get; set; }
        private BaseViewModel email { get; set; }
        private BaseViewModel password { get; set; }
        private BaseViewModel confirmPassword { get; set; }
        private BaseViewModel storeName { get; set; }
        private BaseViewModel phoneNo { get; set; }
        private BaseViewModel selectedCategories { get; set; }
        private long storeUserId { get; set; }
        private BaseViewModel username { get; set; }
        private string backgroundColor { get; set; }
        public Command SignUpCommand { get; set; }
        public Command LoginCommand { get; set; }
        public Command OpenCategoriesCommand { get; set; }
        public ObservableCollection<CategoryDTO> listCategories { get; set; }
        public BaseViewModel SelectedCategories
        {
            get { return this.selectedCategories; }
            set
            {
                if (this.selectedCategories == value)
                {
                    return;
                }

                this.selectedCategories = value;
                this.NotifyPropertyChanged();
            }
        }
        public ObservableCollection<CategoryDTO> ListCategories
        {
            get { return this.listCategories; }
            set
            {
                if (this.listCategories == value)
                {
                    return;
                }

                this.listCategories = value;
                this.NotifyPropertyChanged();
            }
        }
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

        public string BackgroundColor
        {
            get { return this.backgroundColor; }
            set
            {
                if (this.backgroundColor == value)
                {
                    return;
                }

                this.backgroundColor = value;
                this.NotifyPropertyChanged();
            }
        }

        public BaseViewModel Address
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

        public BaseViewModel PhoneNo
        {
            get { return this.phoneNo; }
            set
            {
                if (this.phoneNo == value)
                {
                    return;
                }

                this.phoneNo = value;
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

        public BaseViewModel Email
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

        public BaseViewModel Password
        {
            get { return this.password; }
            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.NotifyPropertyChanged();
            }
        }

        public BaseViewModel ConfirmPassword
        {
            get { return this.confirmPassword; }
            set
            {
                if (this.confirmPassword == value)
                {
                    return;
                }

                this.confirmPassword = value;
                this.NotifyPropertyChanged();
            }
        }

        public BaseViewModel StoreName
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

        public BaseViewModel Username
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
