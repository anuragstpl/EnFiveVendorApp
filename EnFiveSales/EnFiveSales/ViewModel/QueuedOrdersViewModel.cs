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
using Xamarin.Forms;

namespace EnFiveSales.ViewModel
{
   public class QueuedOrdersViewModel : AddRecieptModel
    {
        public ObservableCollection<QueuedOrdersModel> RecieptsData { get; set; }
        public Command SelectedOrderCommand { get; set; }

        public QueuedOrdersViewModel()
        {
            Task.Run(async () => { await GetReciepts(); }).Wait();
            this.SelectedOrderCommand = new Command(this.SelectedOrderClicked);
        }

        private async void SelectedOrderClicked(object obj)
        {
            int recieptID = Convert.ToInt32(((QueuedOrdersModel)obj).RecieptID);
            var mdp = (Application.Current.MainPage as MasterDetailPage);
            var navPage = mdp.Detail as NavigationPage;
            if (navPage.Navigation.NavigationStack.Count == 0 ||
                            navPage.Navigation.NavigationStack.Last().GetType() != typeof(QueuedOrderProducts))
            {
                await navPage.PushAsync(new QueuedOrderProducts(recieptID), true);
            }
        }
        private async Task<GetRecieptResponse> GetReciepts()
        {
            JsonValue GetRecieptResponse = await HttpRequestHelper<string>.GetRequest(ServiceTypes.GetOrderedRecieptsForStore,SessionHelper.AccessToken);
            GetRecieptResponse getRecieptResponse = JsonConvert.DeserializeObject<GetRecieptResponse>(GetRecieptResponse.ToString());
            if (getRecieptResponse.IsSuccess)
            {
                //bind data in listView   
                List<QueuedOrdersModel> lstGetReciepts = getRecieptResponse.LstReciepts.Select(dc => new QueuedOrdersModel()
                {
                    CreatedOn = dc.CreatedOn,
                    Name = dc.Name,
                    Price = dc.Price,
                    RecieptID = dc.RecieptID,
                    Status = dc.Status,
                    StoreID = dc.StoreID
                }).ToList();

               
                RecieptsData = new ObservableCollection<QueuedOrdersModel>();

                foreach (QueuedOrdersModel getReciept in lstGetReciepts)
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

    }
}
