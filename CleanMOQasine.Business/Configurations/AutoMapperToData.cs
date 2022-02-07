using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Business.Configurations
{
    public class AutoMapperToData: Profile
    {
        public AutoMapperToData()
        {
            CreateMap<CleaningAdditionModel, CleaningAddition>().ReverseMap();
            CreateMap<CleaningTypeModel, CleaningType>().ReverseMap();
        }


    }
}
