using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using EnFiveSales.View.Store;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Json;
using System.Text;
using Xamarin.Forms;

namespace EnFiveSales.ViewModel 
{
    public class CreateListViewModel : BaseViewModel
    {
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
        public Command AddRecieptCommand { get; set; }
        public CreateListViewModel()
        {
            this.AddRecieptCommand = new Command(this.AddRecieptClicked);
        }

        private async void AddRecieptClicked(object obj)
        {
            AddRecieptRequest addRecieptRequest = new AddRecieptRequest();
            addRecieptRequest.AuthToken = SessionHelper.AccessToken;
            RecieptDTO recieptDTO = new RecieptDTO();
            recieptDTO.AddedOn = DateTime.Now.ToString();
            recieptDTO.Name = Name;
            recieptDTO.Price = "";
            recieptDTO.RecieptID = 0;
            recieptDTO.Status = ReceiptStatusEnum.New.ToString();
            recieptDTO.StoreID = 0;
            addRecieptRequest.recieptDTO = recieptDTO;
            JsonValue AddRecieptResponse = await HttpRequestHelper<AddRecieptRequest>.POSTreq(ServiceTypes.AddReciept, addRecieptRequest);
            AddRecieptResponse addRecieptResponse = JsonConvert.DeserializeObject<AddRecieptResponse>(AddRecieptResponse.ToString());
            if (addRecieptResponse.IsSuccess)
            {
                var mdp = (Application.Current.MainPage as MasterDetailPage);
                var navPage = mdp.Detail as NavigationPage;
                await navPage.PushAsync(new ListManagement(), true);
            }
        }
    }
}
