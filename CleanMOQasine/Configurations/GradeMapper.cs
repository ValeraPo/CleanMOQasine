using AutoMapper;
using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanMOQasine.Business.Configurations;

namespace CleanMOQasine.API.Configurations
{
    public class GradeMapper : Profile
    {
        public GradeMapper() 
        {
            CreateMap<GradeModel, GradeBaseOutputModel>();
            CreateMap<GradeBaseInputModel, GradeModel>();
        }

        public static Mapper GetInstance()
        {
            return null;
        }
        
    }
}
