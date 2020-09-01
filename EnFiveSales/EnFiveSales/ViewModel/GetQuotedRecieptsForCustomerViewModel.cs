using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.Model;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using EnFiveSales.View.Store;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EnFiveSales.ViewModel
{
    public class GetQuotedRecieptsForCustomerViewModel : GetQuotedRecieptsForCustomerModel
    {
        public ObservableCollection<GetQuotedRecieptsForCustomerModel> getQuotedRecieptsForCustomerData { get; set; }

        public ObservableCollection<GetQuotedRecieptsForCustomerModel> GetQuotedRecieptsForCustomerData
        {
            get { return this.getQuotedRecieptsForCustomerData; }
            set
            {
                if (this.getQuotedRecieptsForCustomerData == value)
                {
                    return;
                }

                this.getQuotedRecieptsForCustomerData = value;
                this.NotifyPropertyChanged();
            }
        }

        public Command SelectedQuoteCommand { get; set; }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await QuotedRecieptForCustomer();

                    IsRefreshing = false;
                });
            }
        }

        public GetQuotedRecieptsForCustomerViewModel()
        {
            Task.Run(async () => { await QuotedRecieptForCustomer(); }).Wait();
           
            this.SelectedQuoteCommand = new Command(this.SelectedQuoteClicked);
        }
        private async Task<GetQuotedRecieptsForCustomerResponce> QuotedRecieptForCustomer()
        {
            string AccessToken = SessionHelper.AccessToken;
            JsonValue GetQuotedRecieptCustResponse = await HttpRequestHelper<String>.GetRequest(ServiceTypes.GetQuotedRecieptsForCustomer, AccessToken);
            GetQuotedRecieptsForCustomerResponce getQuotedRecieptsForCustomerResponce = JsonConvert.DeserializeObject<GetQuotedRecieptsForCustomerResponce>(GetQuotedRecieptCustResponse.ToString());
            if (getQuotedRecieptsForCustomerResponce.IsSuccess)
            {
                List<GetQuotedRecieptsForCustomerModel> lstGetReciepts = getQuotedRecieptsForCustomerResponce.LstReciepts.Select(dc => new GetQuotedRecieptsForCustomerModel()
                {
                    Name = dc.Name,
                    Price = dc.Price,
                    RecieptID = dc.RecieptID,
                    Status = dc.Status,
                    StoreID = dc.StoreID,
                    StoreName = dc.StoreName,
                    Username = dc.Username
                }).ToList();

                GetQuotedRecieptsForCustomerData = new ObservableCollection<GetQuotedRecieptsForCustomerModel>();

                foreach (GetQuotedRecieptsForCustomerModel getReciept in lstGetReciepts)
                {
                    GetQuotedRecieptsForCustomerData.Add(getReciept);
                }
            }
            else
            {
            }
            return getQuotedRecieptsForCustomerResponce;
        }

        private async void SelectedQuoteClicked(object obj)
        {
            GetQuotedRecieptsForCustomerModel getQuotedRecieptsForCustomerModel = (GetQuotedRecieptsForCustomerModel)obj;
            var mdp = (Application.Current.MainPage as MasterDetailPage);
            var navPage = mdp.Detail as NavigationPage;
            if (navPage.Navigation.NavigationStack.Count == 0 ||
                            navPage.Navigation.NavigationStack.Last().GetType() != typeof(Quotes))
            {
                await navPage.PushAsync(new Quotes((int)getQuotedRecieptsForCustomerModel.RecieptID, (int)getQuotedRecieptsForCustomerModel.StoreID), true);
            }
        }
       

    }
}
