using Microsoft.AspNet.Identity;
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
    public class ContractorController : ApiController
    {
        private ContractorService CreateService()
        {
            return new ContractorService();
        }
        /// <summary>
        /// This create a contractor within the database.
        /// </summary>
        /// <param name="model">Model must contain name, description, phone number, and category id</param>
        /// <returns>Returns 200 when the contractor is successfully created</returns>
        [HttpPost]
        public IHttpActionResult CreateContractor(ContractorCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var service = CreateService();
            if (!service.AddContractor(model))
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Retrieves all contractors from the server
        /// </summary>
        /// <returns>Returns a list of contractors, the list can be empty</returns>
        [HttpGet]
        public IHttpActionResult GetContractors()
        {
            var service = CreateService();
            var items = service.GetContractors();
            if (items == null)
                return NotFound();
            return Ok(items);
        }
        /// <summary>
        /// Gather all contractors based on the category of work that they do
        /// </summary>
        /// <param name="categoryId">The id of the category you are searching for</param>
        /// <returns>Returns a list of contractors with the same category, the list can be empty</returns>
        [HttpGet]
        public IHttpActionResult GetContractorsByCategory(int categoryId)
        {
            var service = CreateService();
            var items = service.GetContractorsByCategory(categoryId);
            if (items == null)
                return NotFound();
            return Ok(items);
        }
        /// <summary>
        /// Search for a specific contractor by their Id
        /// </summary>
        /// <param name="id">The id of the contractor you are searching for</param>
        /// <returns>A detailed view of the contractor</returns>
        [HttpGet]
        public IHttpActionResult GetContractor(int id)
        {
            var service = CreateService();
            var item = service.GetContractor(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        /// <summary>
        /// Allows for the update to the contractor's information
        /// </summary>
        /// <param name="model">To update a contractor it requires: Name, Description, Phone Number, CategoryId</param>
        /// <returns>Returns a 200 when successfully updated</returns>
        [HttpPut]
        public IHttpActionResult UpdateContractor(ContractorEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var service = CreateService();
            if (!service.UpdateContractor(model))
                return InternalServerError();
            return Ok();
        }
        /// <summary>
        /// Deletes the contractor from the database
        /// </summary>
        /// <param name="id">Id of the contractor to be deleted</param>
        /// <returns>Returns a 200 when successfully deleted</returns>
        [HttpDelete]
        public IHttpActionResult DeleteContractor(int id)
        {
            var service = CreateService();
            if (!service.DeleteContractor(id))
                return NotFound();
            return Ok();
        }

        //[HttpGet]
        //public IHttpActionResult GetContractorReviews(int id)
        //{
        //    var service = CreateService();
        //    var item = service.GetContractorReviews(id);
        //    if (item == null)
        //        return NotFound();
        //    return Ok(item);
        //}

        //[HttpPut]
        //public IHttpActionResult AddReviewForContractor(ContractorReview review)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    var service = CreateService();
        //    if (!service.AddReviewForContractor(review))
        //        return InternalServerError();
        //    return Ok();
        //}
    }
}