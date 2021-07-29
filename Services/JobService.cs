using ContractIt.Models;
using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class JobService
    {
        private Guid _userId;
        public JobService(Guid userId)
        {
            _userId = userId;
        }
        public bool AddJob(JobCreate model)
        {
            var entity = new Job() { Title = model.Title, Description = model.Description, Address = model.Address, PhoneNumber = model.PhoneNumber, AuthorId = _userId, Categoryid = model.CategoryId };
            using (var ctx = new ApplicationDbContext())
            {
                entity.Category = ctx.Categories.Find(entity.Categoryid);
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var query = ctx.Jobs
                        .Where(q => q.AuthorId == _userId)
                        .Select(q => new JobListItem() { Title = q.Title, Description = q.Description, Id = q.Id, Category = q.Category });
                    return query.ToArray();
                }
                catch
                {
                    return null;
                }
            }
        }
        public JobDetail GetJob(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Jobs.Single(e => e.Id == id && e.AuthorId == _userId);
                    return new JobDetail()
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Description = entity.Description,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address,
                        Category = ctx.Categories.Find(entity.Categoryid)
                    };
                }
                catch
                {
                    return null;
                }
            }
        }
        public IEnumerable<JobListItem> GetJobsByCategory(int CategoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var jobs = ctx.Jobs
                        .Where(j => j.Categoryid == CategoryId && j.AuthorId == _userId)
                        .Select(j => new JobListItem() { Title = j.Title, Description = j.Description, Id = j.Id, Category = j.Category });
                    return jobs.ToArray();
                }
                catch
                {
                    return null;
                }
            }
        }
        public bool UpdateJob(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs.Single(e => e.Id == model.Id && e.AuthorId == _userId);
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Address = model.Address;
                entity.Category = model.Category;
                entity.Categoryid = model.CategoryId;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteJob(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs.Single(e => e.Id == id && e.AuthorId == _userId);
                ctx.Jobs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
