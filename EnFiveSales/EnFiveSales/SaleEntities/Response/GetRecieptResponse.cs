using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
    public class GetRecieptResponse : BaseEntityResponse 
    {
        [JsonProperty("reciepts")]
        public List<RecieptDTO> LstReciepts { get; set; }
    }
}
