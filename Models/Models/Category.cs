using System;
using System.Collections.Generic;
using System.Text;

namespace RetailSkuApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int DepartmentId { get; set; }
    }
}
