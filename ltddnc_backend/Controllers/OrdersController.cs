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
        private ProductsRepository _productsRepository;
        private readonly IMapper mapper;

        public OrdersController(DataDbContext dbContext, IMapper mapper)
        {
            this._ordersRepository = new OrdersRepository(dbContext);
            this._productsRepository = new ProductsRepository(dbContext);
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
                    CreateDate = orderParams.Order.CreateDate,
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
                    OrderDetail orderDetail = _ordersRepository.GetFirstOrderDetailByOrder(order.Id);
                    Product product = _productsRepository.GetProductByID(orderDetail.IdProduct);
                    OrderDetailUI orderDetailUI = mapper.Map<OrderDetailUI>(orderDetail);
                    orderDetailUI.NameProduct = product.Name;
                    orderDetailUI.ImageProduct = product.Image;
                    order.FirstOrderDetail = orderDetailUI;
                }

                return Ok(lOrdersUI);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetOrderDetailByIdOrder/{idOrder}")]
        public async Task<IActionResult> GetOrderDetailByIdOrder(int idOrder)
        {
            try
            {
                IQueryable<OrderDetail> lOrderDetails;

                lOrderDetails = await _ordersRepository.GetAllOrderDetailByOrder(idOrder);
                List<OrderDetailUI> lOrderDetailUI = mapper.Map<List<OrderDetailUI>>(lOrderDetails);
                
                foreach (var orderDetail in lOrderDetailUI)
                {
                    Product product = _productsRepository.GetProductByID(orderDetail.IdProduct);
                    orderDetail.NameProduct = product.Name;
                    orderDetail.ImageProduct = product.Image;
                }

                return Ok(lOrderDetailUI);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("UpdateStateOrder/{idOrder}&&{state}")]
        public IActionResult UpdateStateOrder(int idOrder, int state)
        {
            try
            {
                var order = _ordersRepository.GetOrderById(idOrder);
                if (order != null)
                {
                    order.State = state;
                    _ordersRepository.UpdateOrder(order);
                    if (!_productsRepository.Save())
                    {
                        return BadRequest();
                    }

                    return Ok();
                }
                else return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
