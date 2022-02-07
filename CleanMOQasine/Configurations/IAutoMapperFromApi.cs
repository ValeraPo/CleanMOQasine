using AutoMapper;

namespace CleanMOQasine.API.Configurations
{
    public interface IAutoMapperFromApi
    {
        Mapper GetInstance();
        Mapper InitAutoMapperFromApi();
    }
}
