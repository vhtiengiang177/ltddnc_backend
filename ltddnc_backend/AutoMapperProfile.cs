using AutoMapper;
using ltddnc_backend.Entity;
using ltddnc_backend.Model;

namespace ltddnc_backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserUI>();
            CreateMap<Cart, CartUI>();
            CreateMap<Order, OrderUI>();
            CreateMap<OrderDetail, OrderDetailUI>();
        }
    }
}
