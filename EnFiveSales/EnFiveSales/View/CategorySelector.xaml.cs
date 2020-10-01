using EnFiveSales.ViewModel;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnFiveSales.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategorySelector : PopupPage
    {
        public CategorySelector()
        {
            CategorySelectorViewModel _collection = new CategorySelectorViewModel();
            InitializeComponent();
            this.BindingContext = _collection;
        }
    }
}