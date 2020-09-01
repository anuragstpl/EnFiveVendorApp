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
    public partial class Quotes : ContentPage
    {
        public Quotes(int receiptID,int storeID)
        {
            InitializeComponent();
            QuotedProductsForStoreViewModal _collection = new QuotedProductsForStoreViewModal( receiptID,  storeID);
            this.BindingContext = _collection;
        }
    }
}