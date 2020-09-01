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
    public partial class ConfirmOrderProducts : ContentPage
    {
        public ConfirmOrderProducts(int receiptID,int storeID)
        {
            InitializeComponent();
            ConfirmOrderProductsViewModal _collection = new ConfirmOrderProductsViewModal(receiptID,  storeID);
            this.BindingContext = _collection;
        }
    }
}