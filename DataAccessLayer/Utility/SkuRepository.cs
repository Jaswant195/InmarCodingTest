using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Interface;
using Microsoft.Extensions.Configuration;
using Models.Models;
using RetailSkuApi.Models;

namespace DataAccessLayer.Utility
{
    public class SkuRepository : ISkuRepository
    {
        public readonly IConfiguration configuration;
        public SkuRepository(IConfiguration config)
        {
            this.configuration = config;
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(this.configuration.GetConnectionString("SqlDbConnection")); }
        }

        public async Task<IEnumerable<SkuMetaDataViewModel>> GetAllSkus(SkuMetaData skuMetaData)
        {
            IEnumerable<SkuMetaDataViewModel> lstSkuMetadata;

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select SM.SkuId, SM.SkuDescription, SM.LocationName, SM.DepartmentName, SM.CategoryName, SM.SubCategoryName from SkuMetaData SM " +
                    "where SM.LocationName = '" + skuMetaData.LocationName + "' and SM.DepartmentName = '" + skuMetaData.DepartmentName + "' and " +
                    " SM.CategoryName = '" + skuMetaData.CategoryName + "' and SM.SubCategoryNames = '" + skuMetaData.SubCategoryName + "'";

                if (con.State == ConnectionState.Closed)
                    con.Open();

                lstSkuMetadata = await con.QueryAsync<SkuMetaDataViewModel>(sQuery).ConfigureAwait(true);
            }

            return lstSkuMetadata;
        }
    }
}
