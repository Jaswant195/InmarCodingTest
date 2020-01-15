using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Microsoft.Extensions.Logging;

namespace RetailSkuAPI.Controllers
{
    [ApiController]
    public class SkuController : ControllerBase
    {
        private readonly ISkuRepository skuRepository;
        private readonly ILogger logger;
        public SkuController(ISkuRepository skuRepository, ILoggerFactory loggerFactory)
        {
            this.skuRepository = skuRepository;
            this.logger = loggerFactory.CreateLogger("RetailSkuLogger");
        }

        [HttpPost]
        [Route("api/v1/getallskus/")]
        public async Task<IActionResult> GetAllSkus([FromBody]SkuMetaData skuMetaData)
        {
            try
            {
                var result = await this.skuRepository.GetAllSkus(skuMetaData);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogInformation($"SkuController -> GetAllSkus - { ex.Message } - {ex.InnerException?.Message}");
                return BadRequest(ex);
            }
        }
    }
}