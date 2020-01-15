using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Interface;
using Microsoft.Extensions.Configuration;
using Models.ViewModels;
using RetailSkuApi.Models;

namespace DataAccessLayer.Utility
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly IConfiguration configuration;
        public CategoryRepository(IConfiguration config)
        {
            this.configuration = config;
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(this.configuration.GetConnectionString("SqlDbConnection")); }
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            IEnumerable<CategoryViewModel> lstCategory;

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select C.CategoryId, C.CategoryName, D.DepartmentName, l.LocationName " +
                                "from Category C  inner join Department D on C.DepartmentId = D.DepartmentId " +
                                "inner join Location L on D.LocationId = L.LocationId";
                if (con.State == ConnectionState.Closed)
                    con.Open();

                lstCategory = await con.QueryAsync<CategoryViewModel>(sQuery).ConfigureAwait(true);
            }

            return lstCategory;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesByDepartment(int departmentId)
        {
            IEnumerable<CategoryViewModel> lstCategory;

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select C.CategoryId, C.CategoryName, D.DepartmentName, l.LocationName " +
                                "from Category C  inner join Department D on C.DepartmentId = D.DepartmentId " +
                                "inner join Location L on D.LocationId = L.LocationId " +
                                "where D.DepartmentId = " + departmentId;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                lstCategory = await con.QueryAsync<CategoryViewModel>(sQuery).ConfigureAwait(true);
            }

            return lstCategory;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesbyLocationAndDepartmentId(int locationId, int departmentId)
        {
            IEnumerable<CategoryViewModel> lstCategory;

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select C.CategoryId, C.CategoryName, D.DepartmentName, l.LocationName " +
                                "from Category C  inner join Department D on C.DepartmentId = D.DepartmentId " +
                                "inner join Location L on D.LocationId = L.LocationId " +
                                "where L.LocationId = " + locationId + " and D.DepartmentId = " + departmentId;

                if (con.State == ConnectionState.Closed)
                    con.Open();

                lstCategory = await con.QueryAsync<CategoryViewModel>(sQuery).ConfigureAwait(true);
            }

            return lstCategory;
        }

        public async Task<CategoryViewModel> GetAllCategorybyLocationDepartmentAndCategoryId(int locationId, int departmentId, int categoryId)
        {
            CategoryViewModel objCategory = new CategoryViewModel();

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select C.CategoryId, C.CategoryName, D.DepartmentName, l.LocationName " +
                                "from Category C  inner join Department D on C.DepartmentId = D.DepartmentId " +
                                "inner join Location L on D.LocationId = L.LocationId " +
                                "where L.LocationId = " + locationId + " and D.DepartmentId = " + departmentId + " and C.CategoryId = " + categoryId;

                if (con.State == ConnectionState.Closed)
                    con.Open();

                objCategory = con.Query<CategoryViewModel>(sQuery).FirstOrDefault();
            }

            return objCategory;
        }
    }
}
