using Newtonsoft.Json;
using System;

namespace EnFiveSales.DTO
{
    public class RecieptDTO
    {
        [JsonProperty("AddedOn")]
        public string AddedOn { get; set; }
 
        [JsonProperty("CreatedOn")]
        public string CreatedOn { get; set; }

        [JsonProperty("IsAvailable")]
        public bool?  IsAvailable { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("OrderCandidateID")]
        public string OrderCandidateID { get; set; }

        [JsonProperty("OrderTime")]
        public string OrderTime { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("ProductID")]
        public long ProductID { get; set; }

        [JsonProperty("Quantity")]
        public string Quantity { get; set; }

        [JsonProperty("ReceiverStoreID")]
        public long? ReceiverStoreID { get; set; }

        [JsonProperty("RecieptID")]
        public long? RecieptID { get; set; }

        [JsonProperty("RecieptOrderID")]
        public long? RecieptOrderID { get; set; }

        [JsonProperty("SenderStoreID")]
        public long? SenderStoreID { get; set; }

        [JsonProperty("StoreID")]
        public long? StoreID { get; set; }

        [JsonProperty("SubTotal")]
        public string SubTotal { get; set; }

        [JsonProperty("UpdatedOn")]
        public string UpdatedOn { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("StoreName")]
        public string StoreName { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }



    }
}