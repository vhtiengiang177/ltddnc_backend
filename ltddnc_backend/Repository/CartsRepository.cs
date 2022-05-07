using ltddnc_backend.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ltddnc_backend.Repository
{
    public class CartsRepository
    {
        private DataDbContext _dbContext;

        public CartsRepository(DataDbContext dataDbContext)
        {
            _dbContext = dataDbContext;
        }
        public async Task<IQueryable<Cart>> GetAllItemsInCart(int customerID)
        {
            var lProductCart = await _dbContext.Carts.Where(p => p.IdUser == customerID).ToListAsync();

            return lProductCart.AsQueryable();
        }

        public Cart GetItemInCart(int customerID, int productID)
        {
            return _dbContext.Carts.FirstOrDefault(p => p.IdUser == customerID && p.IdProduct == productID);
        }

        public Cart AddItemToCart(Cart cart)
        {
            try
            {
                var result = _dbContext.Carts.Add(cart);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            catch
            {
                throw;
            }
        }

        public void UpdateCart(Cart cart)
        {
            _dbContext.Attach(cart);
            _dbContext.Entry(cart).State = EntityState.Modified;
        }

        public void DeleteItemInCart(Cart cart)
        {
            if (_dbContext.Entry(cart).State == EntityState.Detached)
            {
                _dbContext.Attach(cart);
            }
            _dbContext.Remove(cart);
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
