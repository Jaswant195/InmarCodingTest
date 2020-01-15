using System;
using System.Collections.Generic;
using System.Text;

namespace RetailSkuApi.Models
{
    public class Subcategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
    }

}
