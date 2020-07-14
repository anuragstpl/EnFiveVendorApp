using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.View.Store;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ReceiptViewModel : BaseViewModel
    {
        private ObservableCollection<RecieptDTO> listReceipt { get; set; }

        private string name { get; set; }

        private int storeID { get; set; }

        public ObservableCollection<RecieptDTO> ListReceipt
        {
            get { return this.listReceipt; }
            set
            {
                if (this.listReceipt == value)
                {
                    return;
                }

                this.listReceipt = value;
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

        public int StoreID
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

        public Command AddRecieptCommand { get; set; }

        public Command AddRecieptPopUpCommand { get; set; }

        public ReceiptViewModel() {
            //GetStoreReciepts API need to be implemented
            RecieptDTO recieptDTO = new RecieptDTO();
            recieptDTO.CreatedOn = DateTime.UtcNow.ToString();
            recieptDTO.Name = "Test Reciept";
            recieptDTO.Status = ReceiptStatusEnum.New.ToString();
            ListReceipt = new ObservableCollection<RecieptDTO>();
            ListReceipt.Add(recieptDTO);
            this.AddRecieptCommand = new Command(this.AddRecieptClicked);
            this.AddRecieptPopUpCommand = new Command(this.AddRecieptPopUpClicked);
        }

        
        private void AddRecieptClicked(object obj)
        {
            //AddReciept API need to be implemented
            //GetStoreReciepts API need to be implemented
            PopupNavigation.PopAsync(true);
        }

        private void AddRecieptPopUpClicked(object obj)
        {
            PopupNavigation.PushAsync(new CreateList());
        }
    }
}
