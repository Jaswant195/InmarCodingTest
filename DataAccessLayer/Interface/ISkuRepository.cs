using Models.Models;
using Models.ViewModels;
using RetailSkuApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ISkuRepository
    {
        Task<IEnumerable<SkuMetaDataViewModel>> GetAllSkus(SkuMetaData skuMetaData);
    }
}
