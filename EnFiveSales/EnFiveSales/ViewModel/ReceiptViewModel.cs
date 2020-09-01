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
using System.Collections.Specialized;

namespace EnFiveSales.ViewModel
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ReceiptViewModel : AddRecieptModel
    {
        public ObservableCollection<AddRecieptModel> RecieptsData { get; set; }

        public ReceiptViewModel()
        {
            Task.Run(async () => { await GetReciepts(); }).Wait();
            this.AddRecieptPopUpCommand = new Command(this.AddRecieptPopUpClicked);
            this.SelectedRecieptCommand = new Command(this.SelectedRecieptClicked);
        }

        private async Task<GetRecieptResponse> GetReciepts()
        {
            JsonValue GetRecieptResponse = await HttpRequestHelper<GetRecieptRequest>.GetRequest(ServiceTypes.GetReciepts, SessionHelper.AccessToken);
            GetRecieptResponse getRecieptResponse = JsonConvert.DeserializeObject<GetRecieptResponse>(GetRecieptResponse.ToString());
            if (getRecieptResponse.IsSuccess)
            {
                List<AddRecieptModel> lstGetReciepts = getRecieptResponse.LstReciepts.Select(dc => new AddRecieptModel()
                {
                    Name = dc.Name,
                    Price = dc.Price,
                    RecieptID = (long)dc.RecieptID,
                    Status = dc.Status
                }).ToList();

                RecieptsData = new ObservableCollection<AddRecieptModel>();

                foreach (AddRecieptModel getReciept in lstGetReciepts)
                {
                    RecieptsData.Add(getReciept);
                }
            }
            else
            {

            }
            return getRecieptResponse;
        }

        private async void SelectedRecieptClicked(object obj)
        {
            int recieptID = Convert.ToInt32(((AddRecieptModel)obj).RecieptID);
            var mdp = (Application.Current.MainPage as MasterDetailPage);
            var navPage = mdp.Detail as NavigationPage;
            if (navPage.Navigation.NavigationStack.Count == 0 ||
                            navPage.Navigation.NavigationStack.Last().GetType() != typeof(ProductList))
            {
                await navPage.PushAsync(new ProductList(recieptID), true);
            }
        }
        private void AddRecieptPopUpClicked(object obj)
        {
            PopupNavigation.PushAsync(new CreateList());
        }
    }

}
