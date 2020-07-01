using System;

namespace EnFiveSales.DTO
{
    public class QuotedProductDTO
    {
        public int OrderCandidateID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string Price { get; set; }
        public string CreatedOn { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string AddedOn { get; set; }
        public string UpdatedOn { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public int RecieptOrderID { get; set; }
        public Nullable<int> RecieptID { get; set; }
        public Nullable<int> SenderStoreID { get; set; }
        public string OrderTime { get; set; }
        public string SubTotal { get; set; }
        public Nullable<int> ReceiverStoreID { get; set; }
    }
}