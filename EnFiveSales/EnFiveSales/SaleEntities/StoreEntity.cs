using System.Collections.Generic;
using EnFiveSales.DTO;
using Newtonsoft.Json;

namespace EnFiveSales.SaleEntities
{
    public class StoreEntity : BaseEntityResponse
    {
        [JsonProperty("userDetails")]
        public List<UserDTO> lstUserDetails { get; set; }
    }
}