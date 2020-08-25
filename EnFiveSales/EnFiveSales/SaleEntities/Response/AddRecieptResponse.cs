using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
   public class AddRecieptResponse : BaseEntityResponse
    {
        [JsonProperty("recieptDTO")]
        public List<RecieptDTO> LstReciept { get; set; }
    }
}
