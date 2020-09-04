using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Data.Interfaces;

namespace PhamaMicroCrm.Api.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompaniesController(ICompanyRepository companyRepository,
                                   IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<>>
    }
}
