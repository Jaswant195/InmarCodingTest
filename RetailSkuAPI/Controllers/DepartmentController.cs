using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RetailSkuAPI.Controllers
{
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        [Route("api/v1/department/")]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var result = await this.departmentRepository.GetAllDepartments();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/v1/location/{locationId}/department/")]
        public async Task<IActionResult> GetAllDepartmentsByLocation(int locationId)
        {
            try
            {
                var result = await this.departmentRepository.GetAllDepartmentsByLocation(locationId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("/api/v1/location/{locationId}/department/{departmentId}")]
        public async Task<IActionResult> GetDepartmentbyLocationAndDepartmentId(int locationId, int departmentId)
        {
            try
            {
                var result = await this.departmentRepository.GetDepartmentbyLocationAndDepartmentId(locationId, departmentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}