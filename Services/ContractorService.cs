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
    public class ContractorService
    {
        public bool AddContractor(ContractorCreate model)
        {
            var entity = new Contractor() { Name = model.Name, Description = model.Description, PhoneNumber = model.PhoneNumber, CategoryId = model.CategoryId };
            using (var ctx = new ApplicationDbContext())
            {
                entity.Category = ctx.Categories.Find(entity.CategoryId);
                ctx.Contractors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ContractorListItem> GetContractors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var query = ctx.Contractors.Select(e => new ContractorListItem() { Id = e.Id, Name = e.Name, Description = e.Description, PhoneNumber = e.PhoneNumber, Category = e.Category });
                    return query.ToArray();
                }
                catch
                {
                    return null;
                }
            }
        }

        public IEnumerable<ContractorListItem> GetContractorsByCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Contractors
                    .Where(q => q.CategoryId == categoryId)
                    .Select(e => new ContractorListItem() { Id = e.Id, Name = e.Name, Description = e.Description, PhoneNumber = e.PhoneNumber, Category = e.Category });
                return query.ToArray();
            }
        }

        public ContractorDetail GetContractor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Contractors.Single(e => e.Id == id);
                    return new ContractorDetail()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Description = entity.Description,
                        PhoneNumber = entity.PhoneNumber,
                        Category = ctx.Categories.Find(entity.CategoryId)
                    };
                }
                catch
                {
                    return null;
                }
            }
        }
        public bool UpdateContractor(ContractorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Contractors.Single(e => e.Id == model.Id);
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Category = model.Category;
                entity.CategoryId = model.CategoryId;
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

        //public ContractorDetailReviews GetContractorReviews(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        try
        //        {
        //            var entity = ctx.Contractors.Single(e => e.Id == id);
        //            return new ContractorDetailReviews()
        //            {
        //                Id = entity.Id,
        //                Name = entity.Name,
        //                Description = entity.Description,
        //                PhoneNumber = entity.PhoneNumber,
        //                Reviews = entity.Reviews,
        //            };
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public bool AddReviewForContractor(ContractorReview review)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        try
        //        {
        //            var entity = ctx.Contractors.Single(e => e.Id == review.Id);
        //            entity.Reviews.Add(review.Review);
        //            return ctx.SaveChanges() == 1;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //}
    }
}
