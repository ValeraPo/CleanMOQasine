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
    public class AutoMapperToData: Profile
    {
        public AutoMapperToData()
        {
            CreateMap<Grade, GradeModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<CleaningAdditionModel, CleaningAddition>().ReverseMap();
            CreateMap<CleaningTypeModel, CleaningType>().ReverseMap();
            CreateMap<OrderModel, Order>().ReverseMap();
            CreateMap<OrderModel, Order>().ReverseMap();
            CreateMap<Payment, PaymentModel>().ReverseMap();
        }
    }
}
