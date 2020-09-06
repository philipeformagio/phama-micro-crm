using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Api.Dtos;
using PhamaMicroCrm.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Api.V1.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
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

        [HttpGet]
        public async Task<IEnumerable<CompanyOutPutDto>> Get()
        {
            var companies = _mapper.Map<IEnumerable<CompanyOutPutDto>>(await _companyRepository.GetAll());
            return companies;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CompanyOutPutDto>> Get(Guid id)
        {
            var company = _mapper.Map<CompanyOutPutDto>(await _companyRepository.GetById(id));

            if (company == null) return NotFound();

            return company;
        }

    }
}
