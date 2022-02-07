using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Business.Configurations
{
    public class AutoMapperToData : Profile
    {
        private static Mapper _instance;
        public AutoMapperToData() 
        {
            CreateMap<Grade, GradeModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<CleaningAdditionModel, CleaningAddition>().ReverseMap();
        }
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
                cfg.CreateMap<Grade, GradeModel>().ReverseMap();
                cfg.CreateMap<Order, OrderModel>().ReverseMap();
                cfg.CreateMap<CleaningAdditionModel, CleaningAddition>().ReverseMap();
            }));
        }
    }
}
