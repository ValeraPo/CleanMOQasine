using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;

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
            CreateMap<Room, RoomModel>().ReverseMap();
        }
    }
}
