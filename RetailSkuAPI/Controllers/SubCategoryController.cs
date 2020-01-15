using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RetailSkuAPI.Controllers
{
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryRepository subCategoryRepository;
        public SubCategoryController(ISubCategoryRepository subCategoryRepository)
        {
            this.subCategoryRepository = subCategoryRepository;
        }

        [HttpGet]
        [Route("api/v1/subcategory/")]
        public async Task<IActionResult> GetAllSubCategories()
        {
            try
            {
                var result = await this.subCategoryRepository.GetAllSubCategories();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/v1/category/{categoryId}/subcategory/")]
        public async Task<IActionResult> GetAllSubCategoriesByCategory(int categoryId)
        {
            try
            {
                var result = await this.subCategoryRepository.GetAllSubCategoriesByCategory(categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/v1/location/{locationId}/department/{departmentId}/category/{categoryId}/subcategory/")]
        public async Task<IActionResult> GetAllSubCategorybyLocationDepartmentAndCategoryId(int locationId, int departmentId, int categoryId)
        {
            try
            {
                var result = await this.subCategoryRepository.GetAllSubCategorybyLocationDepartmentAndCategoryId(locationId, departmentId, categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/v1/location/{locationId}/department/{departmentId}/category/{categoryId}/subcategory/{subcategoryId}")]
        public async Task<IActionResult> GetAllSubCategorybyLocationDepartmentAndCategoryIdSubcategoryId(int locationId, int departmentId, int categoryId, int subcategoryId)
        {
            try
            {
                var result = await this.subCategoryRepository.GetAllSubCategorybyLocationDepartmentAndCategoryIdSubcategoryId(locationId, departmentId, categoryId, subcategoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}