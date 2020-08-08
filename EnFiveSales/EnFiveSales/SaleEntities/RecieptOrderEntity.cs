namespace EnFiveSales.SaleEntities
{
    public class RecieptOrderEntity : BaseEntityRequest
    {
        public int RecieptOrderID { get; set; }
        public int RecieptID { get; set; }
        public int SenderStoreID { get; set; }
        public string OrderTime { get; set; }
        public int ReceiverStoreID { get; set; }
    }
}