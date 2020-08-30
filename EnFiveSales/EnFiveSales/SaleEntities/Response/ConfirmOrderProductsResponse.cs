using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
    class ConfirmOrderProductsResponse : BaseEntityResponse
    {
        [JsonProperty("reciepts")]
        public List<RecieptDTO> LstReciepts { get; set; }
    }
}
