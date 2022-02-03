using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            }));
        }
    }
}
