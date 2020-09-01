using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
    public class UpdateProductAvailabilityRequest : BaseEntityRequest
    {
        [JsonProperty("productInfo")]
        public List<ProductDTO> ProductInfo { get; set; }
    }
}
