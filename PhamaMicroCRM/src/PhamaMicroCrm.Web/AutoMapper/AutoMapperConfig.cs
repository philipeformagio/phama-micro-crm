using AutoMapper;
using PhamaMicroCrm.Data.ResultSets;
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
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Contact, ContactViewModel>().ReverseMap();
            CreateMap<Note, NoteViewModel>().ReverseMap();
            CreateMap<QuantityNotesPerCompany, QuantityNotesPerCompanyViewModel>().ReverseMap();
        }
    }
}
