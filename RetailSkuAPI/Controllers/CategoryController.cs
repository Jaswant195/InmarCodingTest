using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RetailSkuAPI.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("api/v1/category/")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var result = await this.categoryRepository.GetAllCategories();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/v1/department/{departmentId}/category/")]
        public async Task<IActionResult> GetAllCategoriesByDepartment(int departmentId)
        {
            try
            {
                var result = await this.categoryRepository.GetAllCategoriesByDepartment(departmentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/v1/location/{locationId}/department/{departmentId}/category/")]
        public async Task<IActionResult> GetAllCategoriesbyLocationAndDepartmentId(int locationId, int departmentId)
        {
            try
            {
                var result = await this.categoryRepository.GetAllCategoriesbyLocationAndDepartmentId(locationId, departmentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/v1/location/{locationId}/department/{departmentId}/category/{categoryId}")]
        public async Task<IActionResult> GetAllCategorybyLocationDepartmentAndCategoryId(int locationId, int departmentId, int categoryId)
        {
            try
            {
                var result = await this.categoryRepository.GetAllCategorybyLocationDepartmentAndCategoryId(locationId, departmentId, categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}