using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ltddnc_backend.Entity;
using ltddnc_backend.Repository;
using ltddnc_backend.Model;

namespace ltddnc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private ReviewsRepository _reviewsRepository;
        private AccountsRepository _accountRepository;
        private ProductsRepository _productsRepository;
        private OrdersRepository _ordersRepository;
        public ReviewsController(DataDbContext dbContext)
        {
            this._reviewsRepository = new ReviewsRepository(dbContext);
            this._accountRepository = new AccountsRepository(dbContext);
            this._productsRepository = new ProductsRepository(dbContext);
            this._ordersRepository = new OrdersRepository(dbContext);
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

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview([FromBody] Review reviewObj)
        {
            try
            {
                User user = _accountRepository.GetUserByID(reviewObj.Id);
                Product product = _productsRepository.GetProductByID(reviewObj.IdProduct);
                IQueryable<Review> lReviews;
                lReviews = await _reviewsRepository.GetReviews();
                Review review = new Review()
                {
                    Id = lReviews.Count() + 1,
                    IdUser = reviewObj.IdUser,
                    IdProduct = reviewObj.IdProduct,
                    Name = user.Name,
                    //Image = product.Image,
                    Comment = reviewObj.Comment,
                    Date = DateTime.Now,
                    Rating = reviewObj.Rating,
                    IdOrder = reviewObj.IdOrder,
                    NameProduct = product.Name,
                    ImageProduct = product.Image
                };

                var result = _reviewsRepository.CreateReview(review);
                _reviewsRepository.Save();

                //update avg rating
                double sumRating = lReviews.Select(r => r.Rating).Sum();
                int countRating = lReviews.Where(r => r.IdProduct == reviewObj.IdProduct).Count();
                if (countRating != 0)
                {
                    product.AvgRating = Math.Round(sumRating / countRating, 2);
                    _productsRepository.UpdateProduct(product);
                }

                //update review state
                Order order = _ordersRepository.GetOrderById(reviewObj.IdOrder);
                order.State = 1;
                _ordersRepository.UpdateOrder(order);

                if (_reviewsRepository.Save())
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }



    }
}
