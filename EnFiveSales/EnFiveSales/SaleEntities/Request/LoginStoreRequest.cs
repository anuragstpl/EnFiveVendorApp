using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
    public class LoginStoreRequest : BaseEntityRequest
    {
        [JsonProperty("PasswordHash")]
        public string PasswordHash { get; set; }

        [JsonProperty("UserNameOREmail")]
        public string UserNameOrEmail { get; set; }
    }
}
