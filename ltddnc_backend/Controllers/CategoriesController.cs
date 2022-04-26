using ltddnc_backend.Entity;
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
    public class CategoriesController : ControllerBase
    {
        private CategoriesRepository _categoriesRepository;
        private ProductsRepository _productsRepository;
        public CategoriesController(DataDbContext dbContext)
        {
            this._categoriesRepository = new CategoriesRepository(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                IQueryable<Category> lCatesgories;

                lCatesgories = await _categoriesRepository.GetAllCategories();
                return Ok(lCatesgories);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("GetCategoryByID/{id}", Name = "GetCategoryByID")]
        public IActionResult GetCategoryByID(int id)
        {
            var category = _categoriesRepository.GetCategoryByID(id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
               
                var result = _categoriesRepository.Create(category);

                if (_categoriesRepository.Save())
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

        [HttpPut("UpdateCategory/{id}", Name = "UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = User.FindFirst("id").Value;
                    if (userId == null) return BadRequest();


                    _categoriesRepository.Update(category);

                    if (_categoriesRepository.Save())
                    {
                        return Ok(category);
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
            return BadRequest(ModelState);
        }

        [HttpPut("DeleteCategory/{id}", Name = "DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var userId = User.FindFirst("id").Value;
                if (userId == null) return BadRequest();

                var category = _categoriesRepository.GetCategoryByID(id);

                if (category == null)
                    return NotFound();

                category.State = 0;
                _categoriesRepository.Update(category);

                int[] idcategories = new int[1];
                idcategories[0] = category.Id;
                var lproduct = _productsRepository.GetProductsByCategoriesID(idcategories);
                foreach (var item in lproduct)
                {
                    item.State = 0;
                    _productsRepository.UpdateProduct(item);
                }

                _categoriesRepository.Save();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }

}
