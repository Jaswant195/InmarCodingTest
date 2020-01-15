using RetailSkuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<int> AddLocation(Location location);
        Task<int> UpdateLocation(Location location);
        Task<int> DeleteLocation(int locationId);
    }
}
