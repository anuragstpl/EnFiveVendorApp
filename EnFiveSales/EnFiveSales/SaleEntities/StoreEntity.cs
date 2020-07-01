using System.Collections.Generic;
using EnFiveSales.DTO;

namespace EnFiveSales.SaleEntities
{
    public class StoreEntity : BaseEntity
    {
        public List<UserDTO> userDetails;
    }
}