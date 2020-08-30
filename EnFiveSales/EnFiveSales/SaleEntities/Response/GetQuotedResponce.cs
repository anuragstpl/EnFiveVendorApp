using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
   public class GetQuotedVendorResponce : BaseEntityResponse
    {
        [JsonProperty("quotedProducts")]
        public List<ProductDTO> LstProducts { get; set; }

    }
}
