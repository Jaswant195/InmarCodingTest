using System;
using System.Collections.Generic;
using System.Text;

namespace RetailSkuApi.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int LocationId { get; set; }
    }
}
