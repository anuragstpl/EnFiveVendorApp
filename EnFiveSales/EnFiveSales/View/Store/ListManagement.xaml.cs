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
    public partial class ListManagement : ContentPage
    {
        private readonly ReceiptViewModel _collection = new ReceiptViewModel();
        public ListManagement()
        {
            InitializeComponent();
            this.BindingContext = _collection;
        }
    }
}