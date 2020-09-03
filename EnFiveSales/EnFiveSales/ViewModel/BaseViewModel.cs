using EnFiveSales.DataService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsNotConnected { get; set; }

        #endregion

        #region Methods

        public BaseViewModel()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }

        ~BaseViewModel()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess != NetworkAccess.Internet)
                DependencyService.Get<IMessage>().LongAlert("Oops, looks like you don't have internet connection :(");
            else
                DependencyService.Get<IMessage>().ShortAlert("Your internet connection is back :)");
        }

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                this.NotifyPropertyChanged();
            }
        }

        #region ValidationEntities

        private string data { get; set; }

        private bool booleanData { get; set; }

        private long longData { get; set; }

        private int intData { get; set; }

        public string Data
        {
            get
            {
                return this.data;
            }

            set
            {
                if (this.data == value)
                {
                    return;
                }
                this.data = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool BooleanData
        {
            get
            {
                return this.booleanData;
            }

            set
            {
                if (this.booleanData == value)
                {
                    return;
                }
                this.booleanData = value;
                this.NotifyPropertyChanged();
            }
        }

        public long LongData
        {
            get
            {
                return this.longData;
            }

            set
            {
                if (this.longData == value)
                {
                    return;
                }
                this.longData = value;
                this.NotifyPropertyChanged();
            }
        }

        public int IntData
        {
            get
            {
                return this.intData;
            }

            set
            {
                if (this.intData == value)
                {
                    return;
                }
                this.intData = value;
                this.NotifyPropertyChanged();
            }
        }

        private bool isNotValid { get; set; }

        public bool IsNotValid
        {
            get
            {
                return this.isNotValid;
            }

            set
            {
                if (this.isNotValid == value)
                {
                    return;
                }
                this.isNotValid = value;
                this.NotifyPropertyChanged();
            }
        }

        private string notValidMessageError { get; set; }

        public string NotValidMessageError
        {
            get
            {
                return this.notValidMessageError;
            }

            set
            {
                if (this.notValidMessageError == value)
                {
                    return;
                }
                this.notValidMessageError = value;
                this.NotifyPropertyChanged();
            }
        }

        private string borderColor { get; set; }

        public string BorderColor
        {
            get
            {
                return this.borderColor;
            }

            set
            {
                if (this.borderColor == value)
                {
                    return;
                }
                this.borderColor = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion
    }
}
