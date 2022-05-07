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
        public async Task<IQueryable<Cart>> GetAllItemsInCart(int idUser)
        {
            var lProductCart = await _dbContext.Carts.Where(p => p.IdUser == idUser).ToListAsync();

            return lProductCart.AsQueryable();
        }

        public void UpdateCart(Cart cart)
        {
            _dbContext.Attach(cart);
            _dbContext.Entry(cart).State = EntityState.Modified;
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
