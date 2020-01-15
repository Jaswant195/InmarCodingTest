using Models.ViewModels;
using RetailSkuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentViewModel>> GetAllDepartments();
        Task<IEnumerable<DepartmentViewModel>> GetAllDepartmentsByLocation(int locationId);
        Task<DepartmentViewModel> GetDepartmentbyLocationAndDepartmentId(int locationId, int departmentId);
    }
}
