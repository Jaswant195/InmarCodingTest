using RetailSkuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interface
{
    public interface ISubCategoryRepository
    {
        List<Subcategory> GetAllSubCategories();
        List<Subcategory> GetAllSubCategoriesByCategory(int catagoryId);
        List<Subcategory> GetAllSubCategorybyLocationDepartmentAndCategoryId(int locationId, int departmentId, int categoryId);
        List<Subcategory> GetAllSubCategorybyLocationDepartmentAndCategoryIdSubcategoryId(int locationId, int departmentId, int categoryId, int uubCategoryId);
    }
}
