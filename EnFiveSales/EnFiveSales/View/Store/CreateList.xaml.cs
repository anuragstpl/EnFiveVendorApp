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
    public partial class CreateList : PopupPage
    {
        private readonly ReceiptViewModel _collection = new ReceiptViewModel();
        public CreateList()
        {
            InitializeComponent();
            this.BindingContext = _collection;
        }
    }
}