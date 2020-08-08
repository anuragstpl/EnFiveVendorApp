using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
    public class RegisterStoreResponse : BaseEntityResponse
    {
        [JsonProperty("UserID")]
        public long UserId { get; set; }

        [JsonProperty("IsLoggedIn")]
        public bool IsLoggedIn { get; set; }

        [JsonProperty("Token")]
        public object Token { get; set; }

      //  public List<UserDTO> lstDTO { get; set; }
    }
}
