﻿using EnFiveSales.ViewModel;
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
    public partial class Login : ContentPage
    {
        private readonly LoginViewModel _collection = new LoginViewModel();
        public Login()
        {
            InitializeComponent();
            this.BindingContext = _collection;
        }
    }
}