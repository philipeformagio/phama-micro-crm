using AutoMapper;
using PhamaMicroCrm.Api.Dtos;
using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Company, CompanyOutPutDto>();
        }
    }
}
