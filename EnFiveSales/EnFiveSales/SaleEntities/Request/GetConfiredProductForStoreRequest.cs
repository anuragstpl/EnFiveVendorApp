using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
    class GetConfiredProductForStoreRequest: BaseEntityRequest
    {
       
            [JsonProperty("RecieptID")]
            public long RecieptId { get; set; }

            [JsonProperty("StoreID")]
            public long StoreId { get; set; }
       
    }
}
