using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;

namespace CleanMOQasine.API.Configurations
{
    public class GradeMapper : Profile
    {
        public GradeMapper()
        {
            CreateMap<GradeModel, GradeBaseOutputModel>();
            CreateMap<GradeBaseInputModel, GradeModel>();
        }
    }
}
