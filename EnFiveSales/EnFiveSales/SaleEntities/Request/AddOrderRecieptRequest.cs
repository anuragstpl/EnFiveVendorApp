using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
   public class AddOrderRecieptRequest : BaseEntityRequest
    {
        [JsonProperty("OrderTime")]
        public string OrderTime { get; set; }

        [JsonProperty("ReceiverStoreID")]
        public long ReceiverStoreId { get; set; }

        [JsonProperty("RecieptID")]
        public long RecieptId { get; set; }

        [JsonProperty("SenderStoreID")]
        public long SenderStoreId { get; set; }

    }
}
