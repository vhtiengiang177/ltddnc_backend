using ltddnc_backend.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ltddnc_backend.Repository
{
    public class ReviewsRepository
    {
        private DataDbContext _dbContext;

        public ReviewsRepository(DataDbContext dataDbContext)
        {
            _dbContext = dataDbContext;
        }

        public async Task<IQueryable<Review>> GetReviewsByIdProduct(int productID)
        {
            var lReview = await _dbContext.Reviews.Where(p => p.IdProduct == productID).ToListAsync();

            return lReview.AsQueryable();
        }

        public Review CreateReview(Review review)
        {
            var result = _dbContext.Reviews.Add(review);

            return result.Entity;
        }

        public async Task<IQueryable<Review>> GetReviews()
        {
            var lReview = await _dbContext.Reviews.ToListAsync();

            return lReview.AsQueryable();
        }

        public int GetCountReview(int idProduct)
        {
            int count =  _dbContext.Reviews.Where(r=>r.IdProduct == idProduct).Count();

            return count;
        }

        public double GetSumRating(int idProduct)
        {
            double sum = _dbContext.Reviews.Where(r => r.IdProduct == idProduct).Select(r => r.Rating).Sum();

            return sum;
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
