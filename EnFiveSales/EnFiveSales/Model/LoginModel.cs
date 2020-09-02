using EnFiveSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.Model
{
    public class LoginModel : BaseViewModel
    {
        private BaseViewModel passwordHash { get; set; }
        private BaseViewModel userNameOREmail { get; set; }

        public BaseViewModel Password
        {
            get { return this.passwordHash; }
            set
            {
                if (this.passwordHash == value)
                {
                    return;
                }

                this.passwordHash = value;
                this.NotifyPropertyChanged();
            }
        }

        public BaseViewModel Username
        {
            get { return this.userNameOREmail; }
            set
            {
                if (this.userNameOREmail == value)
                {
                    return;
                }

                this.userNameOREmail = value;
                this.NotifyPropertyChanged();
            }
        }

    }
}
