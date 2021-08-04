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
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>Returns a list of all categories, the list can be empty</returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            if (categories == null)
                return NotFound();
            return Ok(categories);
        }
        /// <summary>
        /// Get a specific category by their Id
        /// </summary>
        /// <param name="id">The id of the category</param>
        /// <returns>Returns a detailed view of the category</returns>
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            CategoryService categoryService = CreateCategoryService();
            var category = categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
        /// <summary>
        /// Creates a new category
        /// </summary>
        /// <param name="category">Requires: JobType, PriceRange, Description</param>
        /// <returns>Returns a 200 when succesfully created</returns>
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
        /// <summary>
        /// Allows for the information of the category to be updated
        /// </summary>
        /// <param name="category">Requires: JobType, Price Range, Description</param>
        /// <returns>Returns a 200 when successfully updated</returns>
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
        /// <summary>
        /// This deletes the category from the database. Job postings and contractor are dependent on categories. So, before it is deleted all jobs and contractors attached to this category have their category set to null. This prevents a cascade on delete.
        /// </summary>
        /// <param name="id">Id of the category to be deleted</param>
        /// <returns>Returns a 200 when successfully deleted</returns>
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
