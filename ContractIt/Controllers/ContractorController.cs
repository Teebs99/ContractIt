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
        [HttpGet]
        public IHttpActionResult GetContractors()
        {
            var service = CreateService();
            var items = service.GetContractors();
            if (items == null)
                return NotFound();
            return Ok(items);
        }

        [HttpGet]
        public IHttpActionResult GetContractorsByCategory(int categoryId)
        {
            var service = CreateService();
            var items = service.GetContractorsByCategory(categoryId);
            if (items == null)
                return NotFound();
            return Ok(items);
        }

        [HttpGet]
        public IHttpActionResult GetContractor(int id)
        {
            var service = CreateService();
            var item = service.GetContractor(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
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