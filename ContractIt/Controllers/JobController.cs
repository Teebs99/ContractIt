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
        
        /// <summary>
        /// Creates a Job Posting
        /// </summary>
        /// <param name="model">The required information for the Job Posting</param>
        /// <returns>Returns 200 When Successful</returns>
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
        /// <summary>
        /// Retrieves job postings by the user
        /// </summary>
        /// <returns>Returns list of jobs, can be an empty list</returns>
        [HttpGet]
        public IHttpActionResult GetJobs()
        {
            var service = CreateService();
            var jobs = service.GetJobs();
            if (jobs == null)
                return NotFound();
            return Ok(jobs);
        }
        /// <summary>
        /// Search for a job by it's id
        /// </summary>
        /// <param name="id">The Id of the job you want to look at</param>
        /// <returns>Returns a detailed view of the job posting</returns>
        [HttpGet]
        public IHttpActionResult GetJob(int id)
        {
            var service = CreateService();
            var job = service.GetJob(id);
            if (job == null)
                return NotFound();
            return Ok(job);
        }
        /// <summary>
        /// Gather all jobs postings by the user within a certain category
        /// </summary>
        /// <param name="CategoryId">The id of the category you are looking at</param>
        /// <returns>Returns list of jobs with the same category, can return an empty list</returns>
        [HttpGet]
        public IHttpActionResult GetJobsByCategory(int CategoryId)
        {
            var service = CreateService();
            var jobs = service.GetJobsByCategory(CategoryId);
            if (jobs == null)
                return NotFound();
            return Ok(jobs);
        }
        /// <summary>
        /// Allows the user to update the job posting
        /// </summary>
        /// <param name="model">The required information for a normal job posting</param>
        /// <returns>Returns 200 when successful</returns>
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
        /// <summary>
        /// Deletes the job posting
        /// </summary>
        /// <param name="id">Id of job posting to be deleted</param>
        /// <returns>Returns 200 when successful</returns>
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
