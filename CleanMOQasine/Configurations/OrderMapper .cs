using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;


namespace CleanMOQasine.API.Configurations
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderInsertInputModel, OrderModel>();
            CreateMap<OrderUpdateInputModel, OrderModel>();
            CreateMap<OrderCleanerInputModel, OrderModel>();
            CreateMap<OrderModel, OrderOutputModel>();
        }

    }
}
