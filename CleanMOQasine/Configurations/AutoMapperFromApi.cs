using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.API.Configurations
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
                cfg.CreateMap<CleaningAdditionInputModel, CleaningAdditionModel>();
                cfg.CreateMap<CleaningAdditionModel, CleaningAdditionOutputModel>();

            }));
        }
    }
}
