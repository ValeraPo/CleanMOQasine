using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.API.Configurations
{
    public class AutoMapperFromApi : IAutoMapperFromApi
    {
        public AutoMapperFromApi() { }

        public Mapper InitAutoMapperFromApi()
        {
            return new Mapper(new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<GradeModel, GradeBaseOutputModel>().ReverseMap();
                 cfg.CreateMap<GradeBaseInputModel, GradeModel>().ReverseMap();
             }));
        }
        public static void InitAutoMapperFromApi()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CleaningAdditionInputModel, CleaningAdditionModel>();
                cfg.CreateMap<CleaningAdditionModel, CleaningAdditionOutputModel>();

            }));
        }
    }
}
