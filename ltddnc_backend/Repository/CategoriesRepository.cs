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
