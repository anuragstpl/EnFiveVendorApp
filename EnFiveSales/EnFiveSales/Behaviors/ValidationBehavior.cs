using EnFiveSales.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EnFiveSales.Behaviors
{
    public class ValidationBehavior : Behavior<RoundedEntry>
    {
        RoundedEntry control;
        string _placeHolder;
        Xamarin.Forms.Color _placeHolderColor;

        protected override void OnAttachedTo(RoundedEntry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            bindable.PropertyChanged += OnPropertyChanged;
            control = bindable;
            _placeHolder = bindable.Placeholder;
            _placeHolderColor = bindable.PlaceholderColor;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                ((RoundedEntry)sender).IsBorderErrorVisible = false;
            }
        }

        protected override void OnDetachingFrom(RoundedEntry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            bindable.PropertyChanged -= OnPropertyChanged;
        }

        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == RoundedEntry.IsBorderErrorVisibleProperty.PropertyName && control != null)
            {
                if (control.IsBorderErrorVisible)
                {
                    control.BorderColor = Color.Red;
                    control.Placeholder = control.ErrorText;
                    control.PlaceholderColor = control.BorderErrorColor;
                    control.Text = string.Empty;
                }
                else
                {
                    control.Placeholder = _placeHolder;
                    control.PlaceholderColor = _placeHolderColor;
                }

            }
        }
    }
}
