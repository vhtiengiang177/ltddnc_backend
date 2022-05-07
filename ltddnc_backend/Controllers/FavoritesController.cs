using ltddnc_backend.Entity;
using ltddnc_backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ltddnc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private FavoritesRepository _favoritesRepository;
        private ProductsRepository _productsRepository;
        public FavoritesController(DataDbContext dbContext)
        {
            this._favoritesRepository = new FavoritesRepository(dbContext);
            this._productsRepository = new ProductsRepository(dbContext);
        }

        [HttpGet("GetAllItemsInFavorite/{id}")]
        public async Task<IActionResult> GetAllItemsInFavorite(int id)
        {
            try
            {
                IQueryable<Favorite> lFavoriteItems;

                List<Product> lProductItems2 = new List<Product>();

                int userId = id;
                if (userId == null) return BadRequest();

                lFavoriteItems = await _favoritesRepository.GetAllItemsInFavorite(id);

                foreach (var item in lFavoriteItems)
                {
                    Product product;
                    product = _productsRepository.GetProductByID(item.IdProduct);
                    if (product != null)
                    {
                        lProductItems2.Add(product);
                    }
                }

                return Ok(lProductItems2);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("AddItemToFavorite")]
        public IActionResult AddItemToFavorite(Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst("id").Value;
                var typeAccount = User.FindFirst("idTypeAccount").Value;
                if (userId == null) return BadRequest("Register or login to add to Favorite");
                if (int.Parse(typeAccount) != 4) return BadRequest("Staff cannot use this function");

                favorite.IdUser = int.Parse(userId);

                var item = _favoritesRepository.GetItemInFavorite(favorite.IdUser, favorite.IdProduct);
                if (item == null)
                {
                    _favoritesRepository.AddItemToFavorites(favorite);
                    if (_favoritesRepository.Save())
                        return Ok(item);
                    return BadRequest();
                }
            }

            return BadRequest("Invalid input");
        }


        [HttpPost]
        public IActionResult DeleteItemsInFavorite(Favorite[] lItems)
        {
            try
            {
                var userId = User.FindFirst("id").Value;
                if (userId == null) return BadRequest();

                foreach (var item in lItems)
                {
                    var itemObj = _favoritesRepository.GetItemInFavorite(int.Parse(userId), item.IdProduct);
                    if (itemObj == null)
                        return NotFound();

                    _favoritesRepository.DeleteItemInFavorite(itemObj);
                    if (!_favoritesRepository.Save())
                    {
                        return BadRequest();
                    }
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
