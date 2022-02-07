using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Business.Configurations
{
    public class AutoMapperToData : Profile
    {
        private static Mapper _instance;
        public AutoMapperToData() { }
        public static Mapper GetInstance()
        {
            if (_instance == null)
                _instance = InitAutoMapperToData();
            return _instance;
        }
        public static Mapper InitAutoMapperToData()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CleaningAdditionModel, CleaningAddition>().ReverseMap();
                cfg.CreateMap<OrderModel, Order>().ReverseMap();
                cfg.CreateMap<OrderModel, Order>().ReverseMap();
            }));
        }
    }
}
