using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Business.Configurations
{
    public class AutoMapperToData
    {
        private static Mapper _instance;
        private AutoMapperToData() { }
        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitAutoMapperToData();
            }
            return _instance;
        }
        public static void InitAutoMapperToData()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CleaningAdditionModel, CleaningAddition>().ReverseMap();
                cfg.CreateMap<CleaningTypeModel, CleaningType>().ReverseMap();
            }));
        }
    }
}
