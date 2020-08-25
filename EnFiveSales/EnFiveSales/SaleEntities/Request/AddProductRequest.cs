using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Request
{
  public class AddProductRequest : BaseEntityRequest 
    {
        //  public string RecieptID { get; set; }
        [JsonProperty("productInfo")]
        public ProductDTO productDTO { get; set; }
    }
}
