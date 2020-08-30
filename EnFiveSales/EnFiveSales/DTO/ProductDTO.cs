using Newtonsoft.Json;
using System;

namespace EnFiveSales.DTO
{
    public class ProductDTO
    {
        [JsonProperty("AddedOn")]
        public string AddedOn { get; set; }

        [JsonProperty("CreatedOn")]
        public string CreatedOn { get; set; }

        [JsonProperty("IsAvailable")]
        public bool? IsAvailable { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("OrderCandidateID")]
        public long OrderCandidateId { get; set; }

        [JsonProperty("OrderTime")]
        public string OrderTime { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("ProductID")]
        public long ProductID { get; set; }

        [JsonProperty("Quantity")]
        public string Quantity { get; set; }

        [JsonProperty("ReceiverStoreID")]
        public long? ReceiverStoreId { get; set; }

        [JsonProperty("RecieptID")]
        public long RecieptID { get; set; }

        [JsonProperty("RecieptOrderID")]
        public long? RecieptOrderId { get; set; }

        [JsonProperty("SenderStoreID")]
        public long? SenderStoreId { get; set; }

        [JsonProperty("StoreID")]
        public long? StoreId { get; set; }

        [JsonProperty("SubTotal")]
        public string SubTotal { get; set; }

        [JsonProperty("UpdatedOn")]
        public string UpdatedOn { get; set; }

      

        

        

        

      

     

      

    }
}