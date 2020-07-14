using EnFiveSales.ViewModel;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnFiveSales.View.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : PopupPage
    {
        private readonly ProductViewModel _collection = new ProductViewModel();
        public AddProduct()
        {
            InitializeComponent();
            this.BindingContext = _collection;
        }
    }
}