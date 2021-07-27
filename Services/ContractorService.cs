using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class ContractorService
    {
        public bool AddContractor(ContractorCreate model)
        {
            var entity = new Contractor() { Name = model.Name, Description = model.Description, PhoneNumber = model.PhoneNumber };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contractors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ContractorListItem> GetContractors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Contractors.Select(e => new ContractorListItem() { Name = e.Name, Description = e.Description, PhoneNumber = e.PhoneNumber });
                return query.ToArray();
            }
        }
        public ContractorDetail GetContractor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Contractors.Single(e => e.Id == id);
                return new ContractorDetail()
                {
                    Name = entity.Name,
                    Description = entity.Description,
                    PhoneNumber = entity.PhoneNumber,
                };
            }
        }
        public bool UpdateContractor(int id, ContractorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Contractors.Single(e => e.Id == id);
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.PhoneNumber = model.PhoneNumber;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteContractor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Contractors.Single(e => e.Id == id);
                ctx.Contractors.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
}
