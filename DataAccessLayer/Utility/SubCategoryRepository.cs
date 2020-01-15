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
    public class SubCategoryRepository : ISubCategoryRepository
    {
        public readonly IConfiguration configuration;
        public SubCategoryRepository(IConfiguration config)
        {
            this.configuration = config;
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(this.configuration.GetConnectionString("SqlDbConnection")); }
        }

        public async Task<IEnumerable<SubCategoryViewModel>> GetAllSubCategories()
        {
            IEnumerable<SubCategoryViewModel> lstSubCategory;

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select SC.SubCategoryId,SC.SubCategoryName, C.CategoryName, D.DepartmentName, l.LocationName " +
                                "from SubCategory SC  inner join Category C on SC.CategoryId = C.CategoryId " +
                                "inner join Department D on D.DepartmentId = C.DepartmentId " +
                                "inner join Location L on D.LocationId = L.LocationId";
                if (con.State == ConnectionState.Closed)
                    con.Open();

                lstSubCategory = await con.QueryAsync<SubCategoryViewModel>(sQuery).ConfigureAwait(true);
            }

            return lstSubCategory;
        }

        public async Task<IEnumerable<SubCategoryViewModel>> GetAllSubCategoriesByCategory(int categoryId)
        {
            IEnumerable<SubCategoryViewModel> lstSubCategory;

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select SC.SubCategoryId,SC.SubCategoryName, C.CategoryName, D.DepartmentName, l.LocationName " +
                                "from SubCategory SC  inner join Category C on SC.CategoryId = C.CategoryId " +
                                "inner join Department D on D.DepartmentId = C.DepartmentId " +
                                "inner join Location L on D.LocationId = L.LocationId where C.CategoryId = " + categoryId;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                lstSubCategory = await con.QueryAsync<SubCategoryViewModel>(sQuery).ConfigureAwait(true);
            }

            return lstSubCategory;
        }

        public async Task<IEnumerable<SubCategoryViewModel>> GetAllSubCategorybyLocationDepartmentAndCategoryId(int locationId, int departmentId, int categoryId)
        {
            IEnumerable<SubCategoryViewModel> lstSubCategory;

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select SC.SubCategoryId,SC.SubCategoryName, C.CategoryName, D.DepartmentName, l.LocationName " +
                                "from SubCategory SC  inner join Category C on SC.CategoryId = C.CategoryId " +
                                "inner join Department D on D.DepartmentId = C.DepartmentId " +
                                "inner join Location L on D.LocationId = L.LocationId where L.LocationId = " + locationId + " and D.DepartmentId = " + departmentId +
                                " and C.CategoryId = " + categoryId;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                lstSubCategory = await con.QueryAsync<SubCategoryViewModel>(sQuery).ConfigureAwait(true);
            }

            return lstSubCategory;
        }

        public async Task<SubCategoryViewModel> GetAllSubCategorybyLocationDepartmentAndCategoryIdSubcategoryId(int locationId, int departmentId, int categoryId, int subCategoryId)
        {
            SubCategoryViewModel objSubCategory = new SubCategoryViewModel();

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select SC.SubCategoryId,SC.SubCategoryName, C.CategoryName, D.DepartmentName, l.LocationName " +
                                "from SubCategory SC  inner join Category C on SC.CategoryId = C.CategoryId " +
                                "inner join Department D on D.DepartmentId = C.DepartmentId " +
                                "inner join Location L on D.LocationId = L.LocationId where L.LocationId = " + locationId + " and D.DepartmentId = " + departmentId +
                                " and C.CategoryId = " + categoryId + " and SC.SubCategoryId = " + subCategoryId;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                objSubCategory = con.Query<SubCategoryViewModel>(sQuery).FirstOrDefault();
            }

            return objSubCategory;
        }
    }
}
