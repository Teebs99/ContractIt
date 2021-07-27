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
            var jobs = service.GetContractors();
            if (jobs == null)
                return NotFound();
            return Ok(jobs);
        }
        [HttpGet]
        public IHttpActionResult GetContractor(int id)
        {
            var service = CreateService();
            var job = service.GetContractor(id);
            if (job == null)
                return NotFound();
            return Ok(job);
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
    }
}