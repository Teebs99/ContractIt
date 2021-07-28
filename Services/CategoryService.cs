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
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                JobType = model.JobType,
                PriceRange = model.PriceRange,
                Description = model.Description,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {

                try
                {
                    var query = ctx.Categories.Select(e => new CategoryListItem
                    {
                        CategoryId = e.CategoryId,
                        JobType = e.JobType,
                        CreatedUtc = e.CreatedUtc,
                        PriceRange = e.PriceRange
                    });
                    return query.ToArray();
                }
                catch
                {
                    return null;
                }
            }
        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity = ctx.Categories.Single(e => e.CategoryId == id);
                    return new CategoryDetail
                    {
                        CategoryId = entity.CategoryId,
                        JobType = entity.JobType,
                        PriceRange = entity.PriceRange,
                        Description = entity.Description,
                        CreatedUtc = entity.CreatedUtc
                    };
                }
                catch
                {
                    return null;
                }
            }
        }
        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == model.CategoryId);

                entity.JobType = model.JobType;
                entity.PriceRange = model.PriceRange;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Single(e => e.CategoryId == categoryId);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
