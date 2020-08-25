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
    public partial class QueuedOrderProducts : ContentPage
    {
        private readonly QueuedOrderProductsViewModal _collection = new QueuedOrderProductsViewModal();
        public QueuedOrderProducts()
        {
            InitializeComponent();
            this.BindingContext = _collection;
        }
    }
}