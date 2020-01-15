using Models.ViewModels;
using RetailSkuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategoryViewModel>> GetAllSubCategories();
        Task<IEnumerable<SubCategoryViewModel>> GetAllSubCategoriesByCategory(int catagoryId);
        Task<IEnumerable<SubCategoryViewModel>> GetAllSubCategorybyLocationDepartmentAndCategoryId(int locationId, int departmentId, int categoryId);
        Task<SubCategoryViewModel> GetAllSubCategorybyLocationDepartmentAndCategoryIdSubcategoryId(int locationId, int departmentId, int categoryId, int uubCategoryId);
    }
}
