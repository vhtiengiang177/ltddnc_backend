using ltddnc_backend.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ltddnc_backend.Repository
{
    public class ProductsRepository
    {
        private DataDbContext _dbContext;

        public ProductsRepository(DataDbContext dataDbContext)
        {
            _dbContext = dataDbContext;
        }

        public async Task<IQueryable<Product>> GetAllProducts()
        {
            var lProduct = await _dbContext.Products.Where(p => p.State > 0).ToListAsync();

            return lProduct.AsQueryable();
        }

        public Product GetProductByID(int productID)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == productID && p.State > 0);
        }
        public Product CreateProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);

            return result.Entity;
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Attach(product);
            _dbContext.Entry(product).State = EntityState.Modified;
        }

        public void DeleteProduct(Product product)
        {
            if (_dbContext.Entry(product).State == EntityState.Detached)
            {
                _dbContext.Attach(product);
            }
            _dbContext.Remove(product);
        }
        public IQueryable<Product> GetProductsByCategoriesID(int[] idCategories)
        {
            int[] distinctIdCategories = idCategories.Distinct().ToArray();

            var lProductItem = _dbContext.Products
                                    .Where(p => distinctIdCategories.Contains((int)p.IdCategory) && p.State > 0).ToList();

            return lProductItem.AsQueryable();
        }

        public IQueryable<Product> GetTopProductBestSellers()
        {
            var lProduct = _dbContext.Products.Where(p => p.State > 0).OrderByDescending(i => i.Stock).ToList();

            return lProduct.AsQueryable();
        }


        public bool Save()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
