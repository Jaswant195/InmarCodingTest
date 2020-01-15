using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Interface;
using RetailSkuApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Models.ViewModels;

namespace DataAccessLayer.Utility
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public readonly IConfiguration configuration;
        public DepartmentRepository(IConfiguration config)
        {
            this.configuration = config;
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(this.configuration.GetConnectionString("SqlDbConnection")); }
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetAllDepartments()
        {
            IEnumerable<DepartmentViewModel> lstDepartment;

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select D.DepartmentId, D.DepartmentName, L.LocationName " +
                                "from   Department D inner join Location L on D.LocationId = L.LocationId";
                if (con.State == ConnectionState.Closed)
                    con.Open();

                lstDepartment = await con.QueryAsync<DepartmentViewModel>(sQuery);
            }

            return lstDepartment;
        }

        public async Task<IEnumerable<DepartmentViewModel>> GetAllDepartmentsByLocation(int locationId)
        {
            IEnumerable<DepartmentViewModel> lstDepartment;

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select D.DepartmentId, D.DepartmentName, L.LocationName " +
                                "from   Department D inner join Location L on D.LocationId = L.LocationId " +
                                "where  L.LocationId = " + locationId;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                lstDepartment = await con.QueryAsync<DepartmentViewModel>(sQuery);
            }

            return lstDepartment;
        }

        public async Task<DepartmentViewModel> GetDepartmentbyLocationAndDepartmentId(int locationId, int departmentId)
        {
            DepartmentViewModel objDepartment = new DepartmentViewModel();

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select D.DepartmentId, D.DepartmentName, L.LocationName " +
                                "from   Department D inner join Location L on D.LocationId = L.LocationId " +
                                "where L.LocationId = " + locationId + " and D.DepartmentId = " + departmentId;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                objDepartment = con.Query<DepartmentViewModel>(sQuery).FirstOrDefault();
            }

            return objDepartment;
        }
    }
}
