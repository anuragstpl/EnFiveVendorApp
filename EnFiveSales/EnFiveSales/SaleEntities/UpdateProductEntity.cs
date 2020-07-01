using System.Collections.Generic;
using EnFiveSales.DTO;

namespace EnFiveSales.SaleEntities
{
    public class UpdateProductEntity : BaseEntity
    {
        public List<ProductDTO> productInfo { get; set; }
    }
}