using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;

namespace CleanMOQasine.API.Configurations
{
    public class AutoMapperFromApi : Profile
    {
        public AutoMapperFromApi() 
        {
            CreateMap<PaymentModel, PaymentOutputModel>();
            CreateMap<PaymentInputModel, PaymentModel>();
        }
    }
}
