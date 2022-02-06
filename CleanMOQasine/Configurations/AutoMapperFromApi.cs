using AutoMapper;
using CleanMOQasine.API.Models.Outputs;
using CleanMOQasine.Business.Models;
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
                cfg.CreateMap<PaymentModel, PaymentOutputModel>()
                .ForMember(a => a.PaymentDate, b => b.MapFrom(src => src.PaymentDate.ToString())).ReverseMap();
            }));
        }
    }
}
