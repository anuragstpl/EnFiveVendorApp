using System;

namespace EnFiveSales.DTO
{
    public class RecieptDTO
    {
        public int RecieptID { get; set; }
        public string Name { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string CreatedOn { get; set; }
        public string Status { get; set; }
    }
}