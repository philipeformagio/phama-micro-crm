using AutoMapper;
using PhamaMicroCrm.Model.Entities;
using PhamaMicroCrm.Web.ViewModels;

namespace PhamaMicroCrm.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<CompanyUnit, CompanyUnitViewModel>().ReverseMap();
        }
    }
}
