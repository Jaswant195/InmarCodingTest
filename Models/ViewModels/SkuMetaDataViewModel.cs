using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class SkuMetaDataViewModel
    {
        public int SkuId { get; set; }
        public string SkuDescription { get; set; }
        public string LocationName { get; set; }
        public string DepartmentName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
    }
}
