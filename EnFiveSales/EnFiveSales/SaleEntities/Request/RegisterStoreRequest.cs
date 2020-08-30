using EnFiveSales.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
    public class RegisterStoreRequest : BaseEntityRequest
    {
        public UserDTO UserInfo { get; set; }

    }
}
