using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
    public class LoginStoreRequest : BaseEntityRequest
    {
        //according to api
        [JsonProperty("PasswordHash")] 
     //  according to control binding
        public string Password { get; set; }

        [JsonProperty("UserNameOREmail")]
        public string Username { get; set; }
    }
}
