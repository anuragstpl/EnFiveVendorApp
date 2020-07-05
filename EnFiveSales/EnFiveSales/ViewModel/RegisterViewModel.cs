using EnFiveSales.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    public class RegisterViewModel : BaseViewModel
    {
        private bool active { get; set; }
        private string address { get; set; }
        private string deviceId { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private string confirmPassword { get; set; }
        private string storeName { get; set; }
        private long storeUserId { get; set; }
        private string username { get; set; }
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

        public string Password
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

        public string ConfirmPassword
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

        public Command SignUpCommand { get; set; }
        public Command LoginCommand { get; set; }

        public RegisterViewModel()
        {
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.LoginCommand = new Command(this.LoginClicked);
        }

        private async void SignUpClicked(object obj)
        {

        }

        private async void LoginClicked(object obj)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new Login());
            });
        }

    }
}
