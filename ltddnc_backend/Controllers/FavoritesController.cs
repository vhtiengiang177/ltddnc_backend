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

        [HttpPost("AddItemToFavorite/{idUser}&&{idProduct}")]
        public IActionResult AddItemToFavorite(int idUser, int idProduct)
        {
            if (ModelState.IsValid)
            {
                var item = _favoritesRepository.GetItemInFavorite(idUser, idProduct);
                if (item == null)
                {
                    Favorite favorite = new Favorite();
                    favorite.IdProduct = idProduct;
                    favorite.IdUser = idUser;
                    
                    _favoritesRepository.AddItemToFavorites(favorite);
                    if (_favoritesRepository.Save())
                        return Ok(item);
                    return BadRequest();
                }
            }

            return BadRequest("Invalid input");
        }


        [HttpDelete("DeleteItemInFavorite/{idUser}&&{idProduct}")]
        public IActionResult DeleteItemsInFavorite(int idUser,int idProduct)
        {
            try
            {
                var itemObj = _favoritesRepository.GetItemInFavorite(idUser, idProduct);
                if (itemObj == null)
                    return NotFound();

                _favoritesRepository.DeleteItemInFavorite(itemObj);
                if (!_favoritesRepository.Save())
                {
                    return BadRequest();
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
