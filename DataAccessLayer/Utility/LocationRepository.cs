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
using RetailSkuApi.Models;

namespace DataAccessLayer.Utility
{
    public class LocationRepository : ILocationRepository
    {
        public readonly IConfiguration configuration;
        public LocationRepository(IConfiguration config)
        {
            this.configuration = config;
        }

        public IDbConnection Connection
        {
            get { return new SqlConnection(this.configuration.GetConnectionString("SqlDbConnection")); }
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            IEnumerable<Location> lstLocation;

            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Select LocationId, LocationName from Location";

                if (con.State == ConnectionState.Closed)
                    con.Open();

                lstLocation = await con.QueryAsync<Location>(sQuery).ConfigureAwait(true);
            }

            return lstLocation;
        }

        public async Task<int> AddLocation(Location location)
        {
            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Insert into Location(LocationName) values ('" + location.LocationName + "')";

                if (con.State == ConnectionState.Closed)
                    con.Open();

               return await con.ExecuteAsync(sQuery).ConfigureAwait(true);
            }
        }

        public async Task<int> UpdateLocation(Location location)
        {
            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Update Location set LocationName = '" + location.LocationName + "' where LocationId = " + location.LocationId;

                if (con.State == ConnectionState.Closed)
                    con.Open();

                return await con.ExecuteAsync(sQuery).ConfigureAwait(true);
            }
        }

        public async Task<int> DeleteLocation(int locationId)
        {
            using (IDbConnection con = this.Connection)
            {
                string sQuery = "Delete from Location where LocationId = " + locationId;

                if (con.State == ConnectionState.Closed)
                    con.Open();

                return await con.ExecuteAsync(sQuery).ConfigureAwait(true);
            }
        }
    }
}
