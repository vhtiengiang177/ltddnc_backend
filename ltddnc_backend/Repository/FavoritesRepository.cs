using ltddnc_backend.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ltddnc_backend.Repository
{
    public class FavoritesRepository
    {
        private DataDbContext _dbContext;

        public FavoritesRepository(DataDbContext dataDbContext)
        {
            _dbContext = dataDbContext;
        }

        public async Task<IQueryable<Favorite>> GetAllItemsInFavorite(int customerID)
        {
            var lProduct = await _dbContext.Favorites.Where(p => p.IdUser == customerID).ToListAsync();

            return lProduct.AsQueryable();
        }

        public Favorite GetItemInFavorite(int customerID, int productID)
        {
            return _dbContext.Favorites.FirstOrDefault(p => p.IdUser == customerID && p.IdProduct == productID);
        }

        public Favorite AddItemToFavorites(Favorite favorite)
        {
            try
            {
                var result = _dbContext.Favorites.Add(favorite);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteItemInFavorite(Favorite favorite)
        {
            if (_dbContext.Entry(favorite).State == EntityState.Detached)
            {
                _dbContext.Attach(favorite);
            }
            _dbContext.Remove(favorite);
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

