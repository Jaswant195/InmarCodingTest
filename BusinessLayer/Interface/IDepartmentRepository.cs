using RetailSkuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interface
{
    public interface IDepartmentRepository
    {
        List<Department> GetAllDepartments();
        List<Department> GetAllDepartmentsByLocation(int locationId);
        Department GetDepartmentbyLocationAndDepartmentId(int locationId, int departmentId);
    }
}
