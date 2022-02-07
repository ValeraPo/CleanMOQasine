using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business;
using CleanMOQasine.Business.Models;


namespace CleanMOQasine.API.Configurations
{
    public class AutoMapperFromApi  : IAutoMapperFromApi
    {
        private static Mapper _instance;
        public AutoMapperFromApi() { }

        public  Mapper GetInstance()
        {
            if (_instance == null)
                _instance = InitAutoMapperFromApi();
            return _instance;
        }

        public Mapper InitAutoMapperFromApi()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CleaningAdditionInputModel, CleaningAdditionModel>();
                cfg.CreateMap<CleaningAdditionModel, CleaningAdditionOutputModel>();
                cfg.CreateMap<OrderInsertInputModel, OrderModel>();
                cfg.CreateMap<OrderUpdateInputModel, OrderModel>();
                cfg.CreateMap<OrderCleanerInputModel, OrderModel>();
                cfg.CreateMap<OrderModel, OrderOutputModel>();

            }));
        }
    }
}
