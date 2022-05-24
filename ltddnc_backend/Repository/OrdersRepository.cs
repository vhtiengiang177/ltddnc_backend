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

        public async Task<IQueryable<OrderDetail>> GetAllOrderDetailByOrder(int idOrder)
        {
            var lOrder = await _dbContext.OrderDetails.Where(p => p.IdOrder == idOrder).ToListAsync();

            return lOrder.AsQueryable();
        }

        public async Task<IQueryable<Order>> GetOrderByState(int idUser, int state)
        {
            var lOrder = await _dbContext.Orders.Where(p => p.IdUser == idUser && p.State == state).ToListAsync();

            return lOrder.AsQueryable();
        }

        public OrderDetail GetFirstOrderDetailByOrder(int idOrder)
        {
            var orderDetail =  _dbContext.OrderDetails.Where(p => p.IdOrder == idOrder).FirstOrDefault();

            return orderDetail;
        }

        public Order CreateOrder(Order order)
        {
            var result = _dbContext.Orders.Add(order);

            return result.Entity;
        }

        public OrderDetail CreateOrderDetail(OrderDetail orderDetail)
        {
            var result = _dbContext.OrderDetails.Add(orderDetail);

            return result.Entity;
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
