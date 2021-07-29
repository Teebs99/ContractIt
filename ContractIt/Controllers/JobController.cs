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
    public class JobController : ApiController
    {
        private JobService CreateService()
        {
            var id = Guid.Parse(User.Identity.GetUserId());
            return new JobService(id);
        }

        [HttpPost]
        public IHttpActionResult CreateJob(JobCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var service = CreateService();
            if (!service.AddJob(model))
                return InternalServerError();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetJobs()
        {
            var service = CreateService();
            var jobs = service.GetJobs();
            if (jobs == null)
                return NotFound();
            return Ok(jobs);
        }
        [HttpGet]
        public IHttpActionResult GetJob(int id)
        {
            var service = CreateService();
            var job = service.GetJob(id);
            if (job == null)
                return NotFound();
            return Ok(job);
        }
        [HttpPut]
        public IHttpActionResult UpdateJob(JobEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var service = CreateService();
            if (!service.UpdateJob(model))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteJob(int id)
        {
            var service = CreateService();
            if (!service.DeleteJob(id))
                return NotFound();
            return Ok();
        }
    }
}
