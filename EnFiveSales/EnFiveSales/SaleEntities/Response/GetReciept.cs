using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
    public class GetReciept : BaseEntityResponse 
    {
        [JsonProperty("CreatedOn")]
        public string CreatedOn { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public object Price { get; set; }

        [JsonProperty("RecieptID")]
        public long RecieptId { get; set; }

        [JsonProperty("Status")]
        public object Status { get; set; }

        [JsonProperty("StoreID")]
        public long StoreId { get; set; }
    }
}
