using EnFiveSales.DTO;
using System.Collections.Generic;

namespace EnFiveSales.Helper
{
    public static class SaleItemGlobal 
    {
        public static string serviceURL = "http://mobile.usdotportal.com/SaleItemService.svc/";

        public static List<CategoryDTO> selectedCategories = new List<CategoryDTO>();
    }
}