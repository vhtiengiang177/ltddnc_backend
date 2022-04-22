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
        public CategoriesController(DataDbContext dbContext)
        {
            this._categoriesRepository = new CategoriesRepository(new DataDbContext());
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

    }
}
