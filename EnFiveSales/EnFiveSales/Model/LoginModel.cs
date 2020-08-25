using EnFiveSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.Model
{
    public class LoginModel : BaseViewModel
    {
        private string passwordHash { get; set; }
        private string userNameOREmail { get; set; }

        public string Password
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

        public string Username
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
