using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
  public   class UpdateRecieptStatusRequest : BaseEntityRequest
    {
        [JsonProperty("recieptDTO")]
        public RecieptDTO updatRrecieptDTO { get; set; }
    }
}
