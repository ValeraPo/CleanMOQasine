using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business;
using CleanMOQasine.Business.Models;

namespace CleanMOQasine.API.Configurations
{
    public class AutoMapperFromApi : Profile
    {
        public AutoMapperFromApi()
        {
            CreateMap<CleaningAdditionInputModel, CleaningAdditionModel>();
            CreateMap<CleaningAdditionModel, CleaningAdditionOutputModel>();
            CreateMap<CleanerInsertInputModel, UserModel>();
            CreateMap<UserUpdateInputModel, UserModel>();
            CreateMap<ClientInsertInputModel, UserModel>();
            CreateMap<UserModel, UserOutputModel>();
            CreateMap<CleaningTypeModel, CleaningTypeOutputModel>();
            CreateMap<CleaningTypeInsertInputModel, CleaningTypeModel>();
            CreateMap<CleaningTypeUpdateInputModel, CleaningTypeModel>();
            CreateMap<RoomInputModel, RoomModel>();
            CreateMap<RoomModel, RoomOutputModel>();
            CreateMap<WorkingTimeModel, WorkingTimeOutputModel>();
            CreateMap<WorkingTimeInsertInputModel, WorkingTimeModel>();
            CreateMap<PaymentOutputModel, PaymentModel>();
            CreateMap<PaymentModel, PaymentInputModel>();
        }
    }
}
