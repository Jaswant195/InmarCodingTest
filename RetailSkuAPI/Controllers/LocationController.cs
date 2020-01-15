using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailSkuApi.Models;

namespace RetailSkuAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository locationRepository;
        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        [HttpGet]
        [Route("api/v1/location/")]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                var result = await this.locationRepository.GetAllLocations();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/v1/AddLocation/")]
        public async Task<IActionResult> AddLocation(Location location)
        {
            try
            {
                var result = await this.locationRepository.AddLocation(location);
                return Created("", location);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("api/v1/UpdateLocation/")]
        public async Task<IActionResult> UpdateLocation(Location location)
        {
            try
            {
                var result = await this.locationRepository.UpdateLocation(location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/DeleteLocation/{locationId}")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            try
            {
                var result = await this.locationRepository.DeleteLocation(locationId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}