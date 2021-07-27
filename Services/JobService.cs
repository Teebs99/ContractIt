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
            var entity = new Job() { Title = model.Title, Description = model.Description, Address = model.Address, PhoneNumber = model.PhoneNumber, AuthorId = _userId };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Jobs.Where(q => q.AuthorId == _userId).Select(q => new JobListItem() { Title = q.Title, Description = q.Description, Id = q.Id});
                return query.ToArray();
            }
        }
        public JobDetail GetJob(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs.Single(e => e.Id == id && e.AuthorId == _userId);
                return new JobDetail()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description,
                    PhoneNumber = entity.PhoneNumber,
                    Address = entity.Address
                };
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
