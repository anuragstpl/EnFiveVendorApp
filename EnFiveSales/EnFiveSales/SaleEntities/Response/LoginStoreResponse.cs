using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
    public class LoginStoreResponse : BaseEntityResponse
    {
        [JsonProperty("UserID")]
        public long UserId { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("PhoneNo")]
        public object PhoneNo { get; set; }

        [JsonProperty("IsLoggedIn")]
        public bool IsLoggedIn { get; set; }

        [JsonProperty("Token")]
        public string Token { get; set; }

        [JsonProperty("PushToken")]
        public string PushToken { get; set; }
    }
}
