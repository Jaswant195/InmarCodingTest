using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string DepartmentName { get; set; }
        public string LocationName { get; set; }
    }
}
