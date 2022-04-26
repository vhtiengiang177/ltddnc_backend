using ltddnc_backend.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ltddnc_backend.Repository
{
    public class CategoriesRepository
    {
        private DataDbContext _dbContext;

        public CategoriesRepository(DataDbContext dataDbContext)
        {
            _dbContext = dataDbContext;
        }

        public Category GetCategoryByID(int categoryID)
        {
            return _dbContext.Categories.FirstOrDefault(p => p.Id == categoryID && p.State > 0);
        }

        public async Task<IQueryable<Category>> GetAllCategories()
        {
            var lCategory = await _dbContext.Categories.ToListAsync();

            return lCategory.AsQueryable();
        }

        public Category Create(Category category)
        {
            var result = _dbContext.Categories.Add(category);

            return result.Entity;
        }

        public void Update(Category category)
        {
            _dbContext.Attach(category);
            _dbContext.Entry(category).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var category = _dbContext.Categories.Where(a => a.Id == id).FirstOrDefault();
            category.State = 0;
            _dbContext.Attach(category);
            _dbContext.Entry(category).State = EntityState.Modified;
        }

        public bool Save()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
