using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
    class GetQuotedRecieptsForCustomerResponce : BaseEntityResponse 
    {
        [JsonProperty("reciepts")]
        public List<RecieptDTO> LstReciepts { get; set; }
    }
}
