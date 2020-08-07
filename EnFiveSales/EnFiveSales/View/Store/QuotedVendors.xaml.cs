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
    public partial class QuotedVendors : ContentPage
    {
        private readonly VendorListViewModel _collection = new VendorListViewModel();
        public QuotedVendors()
        {
            InitializeComponent();
            this.BindingContext = _collection;
        }
    }
}