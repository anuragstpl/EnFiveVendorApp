﻿using Newtonsoft.Json;
using System;

namespace EnFiveSales.DTO
{
    public class ProductDTO
    {
        [JsonProperty("AddedOn")]
        public string AddedOn { get; set; }

        [JsonProperty("IsAvailable")]
        public bool? IsAvailable { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("ProductID")]
        public long ProductID { get; set; }

        [JsonProperty("Quantity")]
        public string Quantity { get; set; }

        [JsonProperty("RecieptID")]
        public long RecieptID { get; set; }

        [JsonProperty("UpdatedOn")]
        public string UpdatedOn { get; set; }
    }
}