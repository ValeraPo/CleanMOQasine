using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Configurations
{
    public class AutoMapperToData : Profile
    {
        public AutoMapperToData() 
        {
            CreateMap<CleaningAdditionModel, CleaningAddition>().ReverseMap();
            CreateMap<Payment, PaymentModel>().ReverseMap();
        }
    }
}
