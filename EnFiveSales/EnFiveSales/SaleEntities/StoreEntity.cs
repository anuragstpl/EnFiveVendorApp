using System.Collections.Generic;
using EnFiveSales.DTO;

namespace EnFiveSales.SaleEntities
{
    public class StoreEntity : BaseEntityRequest
    {
        public List<UserDTO> userDetails;
    }
}