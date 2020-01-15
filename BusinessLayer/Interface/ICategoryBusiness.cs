using RetailSkuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interface
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        List<Category> GetAllCategoriesByDepartment(int departmentId);
        List<Category> GetAllCategoriesbyLocationAndDepartmentId(int locationId, int departmentId);
        List<Category> GetAllCategorybyLocationDepartmentAndCategoryId(int locationId, int departmentId, int categoryId);
    }
}
