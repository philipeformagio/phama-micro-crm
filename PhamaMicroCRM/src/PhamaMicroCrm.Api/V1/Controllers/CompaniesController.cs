﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Api.Dtos;
using PhamaMicroCrm.Data.Interfaces;
using System.Collections.Generic;
using System.IO.Compression;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Api.V1.Controllers
{
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

        public async Task<IEnumerable<CompanyOutPutDto>> Get()
        {
            var companies = _mapper.Map<IEnumerable<CompanyOutPutDto>>(await _companyRepository.GetAll());
            return companies;
        }
    }
}
