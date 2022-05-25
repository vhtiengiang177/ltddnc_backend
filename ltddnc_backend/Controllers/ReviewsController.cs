using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ltddnc_backend.Entity;
using ltddnc_backend.Repository;

namespace ltddnc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private ReviewsRepository _reviewsRepository;
        public ReviewsController(DataDbContext dbContext)
        {
            this._reviewsRepository = new ReviewsRepository(dbContext);
        }

        [HttpGet("getreviewsbyidproduct/{id}", Name = "getreviewsbyidproduct")]
        public async Task<IActionResult> GetReviewsByIdProduct(int id)

        {
            IQueryable<Review> lReviews;
            lReviews = await _reviewsRepository.GetReviewsByIdProduct(id);

            if (lReviews == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lReviews);
            }
        }

       
    }
}
