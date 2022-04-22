using ltddnc_backend.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ltddnc_backend.Repository
{
    public class OrdersRepository
    {
        private DataDbContext _dbContext;

        public OrdersRepository(DataDbContext dataDbContext)
        {
            _dbContext = dataDbContext;
        }

        public async Task<IQueryable<Order>> GetAllOrdersByState(int state)
        {
            var lOrder = await _dbContext.Orders.Where(p => p.State == state).ToListAsync();

            return lOrder.AsQueryable();
        }

        public async Task<IQueryable<Order>> GetAllOrders()
        {
            var lOrder = await _dbContext.Orders.ToListAsync();

            return lOrder.AsQueryable();
        }

        public async Task<IQueryable<OrderDetail>> GetAllOrderDetailByOrder(int order)
        {
            var lOrder = await _dbContext.OrderDetails.Where(p => p.IdOrder == order).ToListAsync();

            return lOrder.AsQueryable();
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
