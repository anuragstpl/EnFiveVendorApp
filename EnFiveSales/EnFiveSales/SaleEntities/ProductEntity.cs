using EnFiveSales.DTO;

namespace EnFiveSales.SaleEntities
{
    public class ProductEntity : BaseEntityRequest
    {
        public ProductDTO productInfo { get; set; }
    }
}