using EnFiveSales.DTO;
using EnFiveSales.Helper;
using EnFiveSales.SaleEntities.Request;
using EnFiveSales.ViewModel;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnFiveSales.SaleEntities.Response;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnFiveSales.View.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateList : PopupPage
    {
        private readonly CreateListViewModel _collection = new CreateListViewModel();
        public CreateList()
        {
            InitializeComponent();
            this.BindingContext = _collection;
        }
    }
}