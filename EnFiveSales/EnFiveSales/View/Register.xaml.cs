using EnFiveSales.ViewModel;
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
    public partial class Register : ContentPage
    {
        private readonly RegisterViewModel _collection = new RegisterViewModel();

        public Register()
        {
            InitializeComponent();
            this.BindingContext = _collection;
        }
    }
}