using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
   public class AddRecieptResponse : BaseEntityResponse
    {
        [JsonProperty("Reciepts")]
        public List<RecieptDTO> LstReciept { get; set; }
    }
}
