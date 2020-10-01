using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.DTO
{
    public class CategoryDTO
    {
        [JsonProperty("AddedAt")]
        public string AddedAt { get; set; }

        [JsonProperty("CategoryID")]
        public long CategoryId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("IsChecked")]
        public bool IsChecked { get; set; }
    }
}
