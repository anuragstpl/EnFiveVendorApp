using EnFiveSales.ViewModel;
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
    public partial class ProductList : ContentPage
    {
        public ProductList(int RecieptID)
        {
            InitializeComponent();
            ProductViewModel _collection = new ProductViewModel(RecieptID);
            BindingContext = _collection;
        }
    }
}