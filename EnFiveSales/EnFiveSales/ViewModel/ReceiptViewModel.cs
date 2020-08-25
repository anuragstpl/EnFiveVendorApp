using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.Model;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using EnFiveSales.View.Store;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Json;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.Linq;
using System.Linq.Expressions;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ReceiptViewModel : AddRecieptModel
    {
        public ObservableCollection<RecieptDTO> RecieptsData { get; set; }
        public Command ShowProductCommand { get; set; }
        public ReceiptViewModel()
        {
            Task.Run(async () => { await GetReciepts(); }).Wait();
            this.AddRecieptCommand = new Command(this.AddRecieptClicked);
            this.AddRecieptPopUpCommand = new Command(this.AddRecieptPopUpClicked);
            this.ShowProductCommand = new Command(this.ShowRecieptProductClicked);
            //this.AddRecieptPopUpCommand = new Command(this.ShowRecieptProductPopUpClicked);
             //  RecieptsData = new ObservableCollection<GetReciept>();
            // selecProductfromList spl = new selecProductfromList();
            //spl.ListViewSelectProductId();
        }

        private async void ShowRecieptProductClicked(object obj)
        {
            ((App)App.Current).ReciptProductMainPage();
        }
        //private void ShowRecieptProductPopUpClicked(object obj)
        //{
        //   PopupNavigation.PushAsync(new ListManagement()); 
        //}

        private async Task<GetRecieptResponse> GetReciepts()
        {
            JsonValue GetRecieptResponse = await HttpRequestHelper<GetRecieptRequest>.GetRequest(ServiceTypes.GetReciepts, SessionHelper.AccessToken);
            GetRecieptResponse getRecieptResponse = JsonConvert.DeserializeObject<GetRecieptResponse>(GetRecieptResponse.ToString());
            if (getRecieptResponse.IsSuccess)
            {
                //bind data in listView
                List<RecieptDTO> lstGetReciepts = getRecieptResponse.LstReciepts.Select(dc => new RecieptDTO()
                {
                    Name = dc.Name,
                    Price = dc.Price,
                    RecieptID = dc.RecieptID,
                    Status = dc.Status,
                    StoreID = dc.StoreID,
                }).ToList();

                RecieptsData = new ObservableCollection<RecieptDTO>();

                foreach (RecieptDTO getReciept in lstGetReciepts)
                {
                    RecieptsData.Add(getReciept);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", getRecieptResponse.Message, "Ok");
            }
            return getRecieptResponse;
        }

        private async void AddRecieptClicked(object obj)
        {
            try
            {
                AddRecieptRequest addRecieptRequest = new AddRecieptRequest();
                addRecieptRequest.AuthToken = SessionHelper.AccessToken;
                RecieptDTO recieptDTO = new RecieptDTO();
                recieptDTO.AddedOn = DateTime.Now.ToString();
                recieptDTO.Name = Name;
                recieptDTO.Price = Price;
                recieptDTO.RecieptID = RecieptID;
                recieptDTO.Status = ReceiptStatusEnum.New.ToString();
                recieptDTO.StoreID = 0;
                addRecieptRequest.recieptDTO = recieptDTO;
                JsonValue AddRecieptResponse = await HttpRequestHelper<AddRecieptRequest>.POSTreq(ServiceTypes.AddReciept, addRecieptRequest);
                AddRecieptResponse addRecieptResponse = JsonConvert.DeserializeObject<AddRecieptResponse>(AddRecieptResponse.ToString());
                if (addRecieptResponse.IsSuccess)
                {
                    Task.Run(async () => { await GetReciepts(); }).Wait();
                    //JsonValue GetRecieptResponse = await HttpRequestHelper<GetRecieptRequest>.GetRequest(ServiceTypes.GetReciepts, SessionHelper.AccessToken);
                    //GetRecieptResponse getRecieptResponse = JsonConvert.DeserializeObject<GetRecieptResponse>(GetRecieptResponse.ToString());
                    //if (getRecieptResponse.IsSuccess)
                    //{
                    //    //bind data in listView
                    //    List<GetReciept> lstGetReciepts = getRecieptResponse.LstReciept.Select(dc => new GetReciept()
                    //    {
                    //        Name = dc.Name,
                    //        Price = dc.Price,
                    //        RecieptId = dc.RecieptId,
                    //        Status = dc.Status,
                    //        StoreId = dc.StoreId,
                    //    }).ToList();

                    //    ObservableCollection<GetReciept> RecieptsDataTemp = new ObservableCollection<GetReciept>();

                    //    foreach (GetReciept getReciept in lstGetReciepts)
                    //    {
                    //        RecieptsDataTemp.Add(getReciept);
                    //    }
                    //    RecieptsData = RecieptsDataTemp;
                    //}
                    //else
                    //{
                    //    await App.Current.MainPage.DisplayAlert("Error", getRecieptResponse.Message, "Ok");
                    //}

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", addRecieptResponse.Message, "Ok");
                }
                PopupNavigation.PopAsync(true);
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");

            }


        }
        private void AddRecieptPopUpClicked(object obj)
        {
            PopupNavigation.PushAsync(new CreateList());
        }
    }

    public class selecProductfromList
    {
        private RecieptDTO selectProductId { get; set; }
        public RecieptDTO SelectProductId   
        {
            get
            {
                return selectProductId;
            }
            set
            {
                if (selectProductId != value)
                {
                    selectProductId = value;
                    ListViewSelectProductId();
                }

            }
        }

        public void ListViewSelectProductId()
        {
            Page page = new Page();
            page.DisplayAlert("Selected Product Id", selectProductId.Name, "OK");
        }
    }

}
