using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business;
using CleanMOQasine.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanMOQasine.API.Configurations
{
    public class AutoMapperFromApi: Profile
    {
        public AutoMapperFromApi() 
        {
            CreateMap<CleaningAdditionInputModel, CleaningAdditionModel>();
            CreateMap<CleaningAdditionModel, CleaningAdditionOutputModel>();
            CreateMap<CleaningTypeModel, CleaningTypeOutputModel>();
            CreateMap<CleaningTypeInsertInputModel, CleaningTypeModel>();
            CreateMap<CleaningTypeUpdateInputModel, CleaningTypeModel>();
            CreateMap<RoomInputModel, RoomModel>();
            CreateMap<RoomModel, RoomOutputModel>();
        }
    }
}
