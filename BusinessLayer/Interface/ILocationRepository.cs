using RetailSkuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interface
{
    public interface ILocationRepository
    {
        List<Location> GetAllLocations();
    }
}
