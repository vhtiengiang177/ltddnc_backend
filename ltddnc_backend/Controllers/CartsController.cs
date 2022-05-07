using ltddnc_backend.Entity;
using ltddnc_backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ltddnc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CartsController : ControllerBase
    {
        private CartsRepository _cartsRepository;
        private ProductsRepository _productsRepository;
        public  CartsController(DataDbContext dbContext)
        {
            this._cartsRepository = new CartsRepository(dbContext);
        }

        [HttpGet("GetAllItemsInCart/{id}")]
        public async Task<IActionResult> GetAllItemsInCart()
        {
            try
            {
                IQueryable<Cart> lProductItems;

                var userId = User.FindFirst("id").Value;
                if (userId == null) return BadRequest();

                lProductItems = await _cartsRepository.GetAllItemsInCart(int.Parse(userId));

                return Ok(lProductItems);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("AddItemToCart")]
        public IActionResult AddItemToCart(Cart cart)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst("id").Value;
                var typeAccount = User.FindFirst("idTypeAccount").Value;
                if (userId == null) return BadRequest("Register or login to add to cart");
                if (int.Parse(typeAccount) != 4) return BadRequest("Staff cannot use this function");

                cart.IdUser = int.Parse(userId);

                var item = _cartsRepository.GetItemInCart(cart.IdUser, cart.IdProduct);
                if (item != null)
                {
                    item.Quantity += cart.Quantity;
                    _cartsRepository.UpdateCart(item);
                    if (_cartsRepository.Save())
                        return Ok(item);
                }
                else
                {
                    _cartsRepository.AddItemToCart(cart);
                    if (_cartsRepository.Save())
                        return Ok(item);
                    return BadRequest();
                }
            }

            return BadRequest("Invalid input");
        }

        [HttpPut("UpdateQuantityItemInCart", Name = "UpdateQuantityItemInCart")]
        public IActionResult UpdateQuantityItemInCart(Cart itemObj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (itemObj != null)
                    {
                        var item = _cartsRepository.GetItemInCart(itemObj.IdUser, itemObj.IdProduct);
                        if (item != null)
                        {
                            item.Quantity = itemObj.Quantity;
                            _cartsRepository.UpdateCart(item);
                            if (!_cartsRepository.Save())
                            {
                                return BadRequest();
                            }
                            return Ok(itemObj);
                        }
                        return BadRequest();
                    }
                }
                catch
                {
                    return BadRequest();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult DeleteItemsInCart(Cart[] lItems)
        {
            try
            {
                var userId = User.FindFirst("id").Value;
                if (userId == null) return BadRequest();

                foreach (var item in lItems)
                {
                    var itemObj = _cartsRepository.GetItemInCart(int.Parse(userId), item.IdProduct);
                    if (itemObj == null)
                        return NotFound();

                    _cartsRepository.DeleteItemInCart(itemObj);
                    if (!_cartsRepository.Save())
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
