using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class SubCategoryViewModel
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public string DepartmentName { get; set; }
        public string LocationName { get; set; }
    }
}
