using EnFiveSales.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.Model
{
   public class GetRecieptModel : BaseViewModel 
    {
        public string authToken { get; set; }
        public string AuthToken
        {
            get { return this.authToken; }
            set
            {
                if (this.authToken == value)
                {
                    return;
                }

                this.authToken = value;
                this.NotifyPropertyChanged();
            }
        }

    }
}
