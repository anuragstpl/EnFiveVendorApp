using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnFiveSales.SaleEntities
{
    public abstract class BaseEntityRequest
    {
        public string AuthToken { get; set; }

    }
}