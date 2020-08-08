using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities
{
    public abstract class BaseEntityResponse
    {
        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("IsSuccess")]
        public bool IsSuccess { get; set; }
    }
}
