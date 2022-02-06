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
using CleanMOQasine.Business.Configurations;

namespace CleanMOQasine.API.Configurations
{
    public class AutoMapperFromApi : IAutoMapperFromApi
    {
        public AutoMapperFromApi() 
        {

        }

        public static Mapper GetInstance()
        {
            return null;
        }
        public Mapper InitAutoMapperFromApi()
        {
            return new Mapper(new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<GradeModel, GradeBaseOutputModel>().ReverseMap();
                 cfg.CreateMap<GradeBaseInputModel, GradeModel>().ReverseMap();
             }));
        }
    }
}
