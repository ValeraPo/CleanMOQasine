using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.API.Models.Outputs;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Configurations
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
    }
}
