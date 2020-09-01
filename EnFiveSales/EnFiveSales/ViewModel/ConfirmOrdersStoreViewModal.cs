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
    class ConfirmOrdersStoreViewModal : ConfirmOrdersModel
    {
        public ObservableCollection<ConfirmOrdersModel> confirmOrderProductsData { get; set; }

        public ObservableCollection<ConfirmOrdersModel> ConfirmOrderProductsData
        {
            get { return this.confirmOrderProductsData; }
            set
            {
                if (this.confirmOrderProductsData == value)
                {
                    return;
                }

                this.confirmOrderProductsData = value;
                this.NotifyPropertyChanged();
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await ConfirmOrderRecieptForCustomer();

                    IsRefreshing = false;
                });
            }
        }

        public ConfirmOrdersStoreViewModal()
        {
            Task.Run(async () => { await ConfirmOrderRecieptForCustomer(); }).Wait();
            this.SelectedRecieptCommand = new Command(this.SelectedRecieptClicked);
        }

        private async void SelectedRecieptClicked(object obj)
        {
            ConfirmOrdersModel confirmOrdersModel = (ConfirmOrdersModel)obj;
            var mdp = (Application.Current.MainPage as MasterDetailPage);
            var navPage = mdp.Detail as NavigationPage;
            if (navPage.Navigation.NavigationStack.Count == 0 ||
                            navPage.Navigation.NavigationStack.Last().GetType() != typeof(ProductList))
            {
                await navPage.PushAsync(new ConfirmOrderProducts((int)confirmOrdersModel.RecieptID,(int)confirmOrdersModel.StoreID), true);
            }
        }

        private async Task<ConfirmOrderProductsResponse> ConfirmOrderRecieptForCustomer()
        {
            string AccessToken = SessionHelper.AccessToken;
            JsonValue GetConfirmOrderProductResponse = await HttpRequestHelper<String>.GetRequest(ServiceTypes.GetConfirmedRecieptsForCustomer, AccessToken);
            ConfirmOrderProductsResponse confirmOrderProductsResponse = JsonConvert.DeserializeObject<ConfirmOrderProductsResponse>(GetConfirmOrderProductResponse.ToString());
            if (confirmOrderProductsResponse.IsSuccess)
            {
                List<ConfirmOrdersModel> lstGetReciepts = confirmOrderProductsResponse.LstReciepts.Select(dc => new ConfirmOrdersModel()
                {
                    CreatedOn = dc.CreatedOn,
                    Name = dc.Name,
                    Price = "Total Price : INR " + dc.Price,
                    RecieptID = dc.RecieptID,
                    Status = Enum.GetName(typeof(ReceiptStatusEnum), Convert.ToInt32(dc.Status)),
                    StoreID = dc.StoreID,
                    StoreName = dc.StoreName,
                    Username = dc.Username
                }).ToList();

                ConfirmOrderProductsData = new ObservableCollection<ConfirmOrdersModel>();

                foreach (ConfirmOrdersModel getReciept in lstGetReciepts)
                {
                    ConfirmOrderProductsData.Add(getReciept);
                }
            }
            else
            {
            }
            return confirmOrderProductsResponse;
        }
    }
}
