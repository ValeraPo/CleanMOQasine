using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.API.Models.Outputs;
using CleanMOQasine.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Configurations
{
    public class AutoMapperFromApi
    {
        private static Mapper _instance;
        private AutoMapperFromApi() { }
        public static Mapper GetInstance()
        {
            if (_instance == null)
            {
                InitAutoMapperFromApi();
            }
            return _instance;
        }
        public static void InitAutoMapperFromApi()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GradeModel, GradeBaseOutputModel>();
                cfg.CreateMap<GradeBaseOutputModel, GradeModel>();
            }));
        }
    }
}
