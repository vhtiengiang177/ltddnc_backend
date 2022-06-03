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

            foreach (var review in lReviews)
            {
                User user = _accountRepository.GetUserByID(review.IdUser);
                review.Name = user.Name;
                review.Image = user.Image;
            }

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
        public async Task<IActionResult> CreateReview([FromBody] List<Review> lRevieParams)
        {
            try
            {
                User user = _accountRepository.GetUserByID(lRevieParams[0].IdUser);
                IQueryable<Review> lReviews;
                lReviews = await _reviewsRepository.GetReviews();

                foreach(var  reviewUI in lRevieParams) {
                    Review reviewObj = new Review()
                    {
                        IdUser = reviewUI.IdUser,
                        IdProduct = reviewUI.IdProduct,
                        Name = user.Name,
                        Image = user.Image,
                        Comment = reviewUI.Comment,
                        Date = reviewUI.Date,
                        Rating = reviewUI.Rating,
                        IdOrder = reviewUI.IdOrder,
                        NameProduct = reviewUI.Name,
                        ImageProduct = reviewUI.Image
                    };

                    var result = _reviewsRepository.CreateReview(reviewObj);
                    _reviewsRepository.Save();


                    Product product = _productsRepository.GetProductByID(reviewObj.IdProduct);
                    //update avg rating
                    double sumRating = _reviewsRepository.GetSumRating(reviewObj.IdProduct);
                    int countRating = _reviewsRepository.GetCountReview(reviewObj.IdProduct);
                    if (countRating != 0)
                    {
                        product.AvgRating = Math.Round(sumRating / countRating, 2);
                        _productsRepository.UpdateProduct(product);
                        _productsRepository.Save();

                    }
                }

                //update review state
                Order order = _ordersRepository.GetOrderById(lRevieParams[0].IdOrder);
                order.ReviewState = 1;
                _ordersRepository.UpdateOrder(order);
                _ordersRepository.Save();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
