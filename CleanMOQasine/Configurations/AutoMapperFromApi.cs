﻿using AutoMapper;
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

            CreateMap<WorkingTimeModel, WorkingTimeOutputModel>()
                .ForMember(output => output.StartTime, opt => opt.ConvertUsing(new TimeOnlyFromStringConverter(), src => src.StartTime))
                .ForMember(output => output.EndTime, opt => opt.ConvertUsing(new TimeOnlyFromStringConverter(), src => src.EndTime))
                .ForMember(output=>output.UserId, opt=>opt.MapFrom(model=>model.User.Id));
            CreateMap<WorkingTimeInsertInputModel, WorkingTimeModel>()
                .ForMember(wtm => wtm.StartTime, opt => opt.ConvertUsing(new TimeOnlyFromStringConverter(), src => src.StartTime))
                .ForMember(wtm => wtm.EndTime, opt => opt.ConvertUsing(new TimeOnlyFromStringConverter(), src => src.EndTime));

            CreateMap<PaymentOutputModel, PaymentModel>();
            CreateMap<PaymentModel, PaymentInputModel>();
        }
    }
}
