using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;


namespace CleanMOQasine.API.Configurations
{
    public class OrderMapper : Profile
    {
        private static Mapper _instance;

        public static Mapper GetInstance()
        {
            return _instance;
        }

        public OrderMapper()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                CreateMap<OrderInsertInputModel, OrderModel>();
                CreateMap<OrderUpdateInputModel, OrderModel>();
                CreateMap<OrderCleanerInputModel, OrderModel>();
                CreateMap<OrderModel, OrderOutputModel>();
            }));
        }

    }
}
