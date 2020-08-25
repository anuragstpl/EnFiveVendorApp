using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
    public class AddRecieptRequest : BaseEntityRequest
    {
        [JsonProperty("recieptDTO")]
        public RecieptDTO recieptDTO { get; set; }

        
    }
}
