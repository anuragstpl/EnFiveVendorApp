using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
    public class GetQuotedProductsForStoreRequest : BaseEntityRequest
    {
        [JsonProperty("RecieptID")]
        public long RecieptId { get; set; }

        [JsonProperty("StoreID")]
        public long StoreId { get; set; }
    }
}
