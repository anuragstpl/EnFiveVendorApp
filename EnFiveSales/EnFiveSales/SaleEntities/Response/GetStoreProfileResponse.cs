using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
    public class GetStoreProfileResponse : BaseEntityResponse
    {
        [JsonProperty("userDetails")]
        public UserDTO userDetails;
    }
}
