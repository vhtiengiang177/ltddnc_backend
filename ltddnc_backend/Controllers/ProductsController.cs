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
    public class ProductsController : ControllerBase
    {
        private ProductsRepository _productsRepository;
        public ProductsController(DataDbContext dbContext)
        {
            this._productsRepository = new ProductsRepository(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                IQueryable<Product> lProducts;

                lProducts = await _productsRepository.GetAllProducts();
                return Ok(lProducts);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("GetProductByID/{id}", Name = "GetProductByID")]
        public IActionResult GetProductByID(int id)
        {
            var product = _productsRepository.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpGet("getproductbycategoryid/{id}", Name = "getproductbycategoryid")]
        public async Task<IActionResult> GetProductsByCategoriesID(int id)

        {
            IQueryable<Product> lProducts;
            lProducts = await _productsRepository.GetProductsByCategoryID(id);

            if (lProducts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(lProducts);
            }
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {

                var result = _productsRepository.CreateProduct(product);

                if (_productsRepository.Save())
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateProduct(Product productObj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productsRepository.UpdateProduct(productObj);
                    if (!_productsRepository.Save())
                    {
                        return BadRequest();
                    }

                    return Ok(productObj);
                }
                catch
                {
                    return BadRequest();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = _productsRepository.GetProductByID(id);

                if (product == null)
                    return NotFound();

                product.State = 0;

                _productsRepository.UpdateProduct(product);
                _productsRepository.Save();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetTop10NewProduct")]
        public async Task<IActionResult> GetTop10NewProduct()
        {
            try
            {

                return Ok(_productsRepository.GetTop10Products());
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
