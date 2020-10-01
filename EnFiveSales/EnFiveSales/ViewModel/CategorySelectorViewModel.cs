using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.SaleEntities.Response;
using EnFiveSales.View;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
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
    public class CategorySelectorViewModel : BaseViewModel
    {
        public Command SelectCategoryCommand { get; set; }
        public ObservableCollection<CategoryDTO> listCategories { get; set; }
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

        public CategorySelectorViewModel()
        {
            this.SelectCategoryCommand = new Command(this.SelectCategoryClicked);
            Task.Run(async () => { await DisplayCategories(); }).Wait();
        }

        public async void SelectCategoryClicked()
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();
            foreach (CategoryDTO item in ListCategories)
            {
                    categories.Add(item);
            }
            SaleItemGlobal.selectedCategories = categories;
            MessagingCenter.Send(categories.First(), "Update");
            await PopupNavigation.Instance.PopAsync();
        }

        private async Task<GetAllCategoriesResponse> DisplayCategories()
        {
            GetAllCategoriesResponse getCategoryResponse = null;
            if (SaleItemGlobal.selectedCategories.Count == 0)
            {
                JsonValue GetCategoryResponse = await HttpRequestHelper<GetRecieptRequest>.ParameterLessGetRequest(ServiceTypes.GetAllCategories);
                getCategoryResponse = JsonConvert.DeserializeObject<GetAllCategoriesResponse>(GetCategoryResponse.ToString());
                if (getCategoryResponse.IsSuccess)
                {
                    ListCategories = new ObservableCollection<CategoryDTO>();
                    foreach (CategoryDTO category in getCategoryResponse.CategoryDtOs)
                    {
                        ListCategories.Add(category);
                    }
                }
                else
                {

                }
            }
            else
            {
                ListCategories = new ObservableCollection<CategoryDTO>();
                foreach (CategoryDTO category in SaleItemGlobal.selectedCategories)
                {
                    ListCategories.Add(category);
                }
            }
            return getCategoryResponse;
        }
    }
}
