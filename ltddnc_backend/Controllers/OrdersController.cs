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
    public class OrdersController : ControllerBase
    {
        private OrdersRepository _ordersRepository;
        private readonly IMapper mapper;

        public OrdersController(DataDbContext dbContext, IMapper mapper)
        {
            this._ordersRepository = new OrdersRepository(dbContext);
            this.mapper = mapper;
        }

        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder([FromBody] OrderParams orderParams)
        {
            try
            {
                Order order = new Order()
                {
                    Name = orderParams.Order.Name,
                    Phone = orderParams.Order.Phone,
                    Address = orderParams.Order.Address,
                    TotalQuantity = orderParams.Order.TotalQuantity,
                    TotalProductPrice = orderParams.Order.TotalProductPrice,
                    IdUser = orderParams.Order.IdUser,
                };

                var result = _ordersRepository.CreateOrder(order);
                _ordersRepository.Save();

                foreach (var orderDetail in orderParams.ListOrderDetail)
                {
                    orderDetail.IdOrder = result.Id;
                    _ordersRepository.CreateOrderDetail(orderDetail);
                }
                
                
                 if (_ordersRepository.Save())
                {
                    return Ok(result);
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

        [HttpGet("GetOrderByState/{idUser}&&{state}")]
        public async Task<IActionResult> GetOrderByState(int idUser, int state)
        {
            try
            {
                IQueryable<Order> lOrders;

                lOrders = await _ordersRepository.GetOrderByState(idUser, state);
                List<OrderUI> lOrdersUI = mapper.Map<List<OrderUI>>(lOrders);

                foreach (var order in lOrdersUI)
                {
                    order.FirstOrderDetail = _ordersRepository.GetFirstOrderDetailByOrder(order.Id);
                }

                return Ok(lOrdersUI);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
