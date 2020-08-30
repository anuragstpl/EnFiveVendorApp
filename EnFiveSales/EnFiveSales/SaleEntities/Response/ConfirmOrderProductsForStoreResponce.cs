using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
    class ConfirmOrderProductsForStoreResponce : BaseEntityResponse
    {
       
            [JsonProperty("quotedProducts")]
            public List<ProductDTO> LstProducts { get; set; }
        
    }
}
