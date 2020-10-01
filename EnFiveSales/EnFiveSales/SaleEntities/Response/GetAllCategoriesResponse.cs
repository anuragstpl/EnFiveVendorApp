using EnFiveSales.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnFiveSales.SaleEntities.Response
{
    public class GetAllCategoriesResponse : BaseEntityResponse
    {
        [JsonProperty("categoryDTOs")]
        public List<CategoryDTO> CategoryDtOs { get; set; }
    }
}
