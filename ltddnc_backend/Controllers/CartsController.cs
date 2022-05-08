using AutoMapper;
using ltddnc_backend.Entity;
using ltddnc_backend.Model;
using ltddnc_backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ltddnc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CartsController : ControllerBase
    {
        private CartsRepository _cartsRepository; 
        private ProductsRepository _productsRepository;
        private readonly IMapper mapper;
        public CartsController(DataDbContext dbContext, IMapper mapper)
        {
            this._cartsRepository = new CartsRepository(dbContext); 
            this._productsRepository = new ProductsRepository(dbContext);
            this.mapper = mapper;
        }

        [HttpGet("GetAllItemsInCart/{idUser}")]
        public async Task<IActionResult> GetAllItemsInCart(int idUser)
        {
            try
            {
                IQueryable<Cart> lCarts;

                lCarts = await _cartsRepository.GetAllItemsInCart(idUser);
                List<CartUI> lCartsUI = mapper.Map<List<CartUI>>(lCarts);

                foreach (var cart in lCartsUI)
                {
                    cart.Product = _productsRepository.GetProductByID(cart.IdProduct);
                }

                return Ok(lCartsUI);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("UpdateCart")]
        public IActionResult UpdateCart([FromBody] List<CartUI> listCartUI)
        {
            try
            {
                foreach (CartUI cartUI in listCartUI)
                {
                    Cart cart = new Cart()
                    {
                        IdUser = cartUI.IdUser,
                        IdProduct = cartUI.IdProduct,
                        Quantity = cartUI.Quantity
                    };
                    var oldItem = _cartsRepository.GetItemInCart(cart.IdUser, cart.IdProduct);
                    if (oldItem != null)
                    {
                        _cartsRepository.UpdateCart(cart);
                    }
                    else
                    {
                        _cartsRepository.AddItemToCart(cart);
                    }
                    _cartsRepository.UpdateCart(cart);
                }
                if (!_cartsRepository.Save())
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

        [HttpPost("AddItem")]
        public IActionResult AddItem([FromBody] Cart cart)
        {
            try
            {
                var oldItem = _cartsRepository.GetItemInCart(cart.IdUser, cart.IdProduct);
                if (oldItem != null)
                {
                    oldItem.Quantity += cart.Quantity;
                    _cartsRepository.UpdateCart(oldItem);
                }
                else
                {
                    _cartsRepository.AddItemToCart(cart);
                }

                if (!_cartsRepository.Save())
                {
                    return BadRequest("Thêm thất bại");
                }
                return Ok("Thêm thành công!");
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
