using EnFiveSales.DTO;
using System.Collections.Generic;

namespace EnFiveSales.SaleEntities
{
    public class QuotedEntity : BaseEntityRequest
    {
        public List<RecieptDTO> reciepts { get; set; }
        public List<UserDTO> users { get; set; }
        public string noReceiptMessage { get; set; }
        public string noUserMessage { get; set; }
    }
}