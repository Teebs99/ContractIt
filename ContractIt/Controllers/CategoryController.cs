using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContractIt.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {

            var categoryService = new CategoryService();
            return categoryService; 
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            if (categories == null)
                return NotFound();
            return Ok(categories);
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
        [HttpGet]
        public IHttpActionResult GetCategoriesByContractor(int ContractorId)
        {
            var service = CreateCategoryService();
            var categories = service.GetCategoryByContractor(ContractorId);
            if (categories == null)
                return NotFound();
            return Ok(categories);
        }
        [HttpPost]
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Put(CategoryEdit category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();

            if (!service.DeleteCategory(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
