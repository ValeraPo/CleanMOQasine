using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;

namespace CleanMOQasine.API.Configurations
{
    public class PaymentMapper : Profile
    {
        public PaymentMapper()
        {
            CreateMap<PaymentModel, PaymentOutputModel>();
            CreateMap<PaymentInputModel, PaymentModel>();
        }
    }
}
