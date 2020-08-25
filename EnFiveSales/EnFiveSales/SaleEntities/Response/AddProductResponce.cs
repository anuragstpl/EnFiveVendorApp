using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
    public class AddProductResponce : BaseEntityResponse 
    {
        [JsonProperty("products")]
        public List<ProductDTO> Lstproducts { get; set; }
    }
}
