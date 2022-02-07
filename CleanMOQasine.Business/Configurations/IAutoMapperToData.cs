using AutoMapper;

namespace CleanMOQasine.Business.Configurations
{
    public interface IAutoMapperToData
    {
        Mapper GetInstance();
        Mapper InitAutoMapperToData();
    }
}