using Models.ViewModels;
using RetailSkuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesByDepartment(int departmentId);
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesbyLocationAndDepartmentId(int locationId, int departmentId);
        Task<CategoryViewModel> GetAllCategorybyLocationDepartmentAndCategoryId(int locationId, int departmentId, int categoryId);
    }
}
