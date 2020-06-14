using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using PhamaMicroCrm.Web.ViewModels;

namespace PhamaMicroCrm.Web.Controllers
{
    public class CompanyUnitsController : BaseController
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyUnitRepository _companyUnitRepository;
        private readonly ICompanyUnitService _companyUnitService;
        private readonly IMapper _mapper;
        public CompanyUnitsController(ICompanyRepository companyRepository,
                                      ICompanyUnitRepository companyUnitRepository,
                                      ICompanyUnitService companyUnitService,
                                      IMapper mapper,
                                      INotifier notifier) : base(notifier)
        {
            _companyRepository = companyRepository;
            _companyUnitService = companyUnitService;
            _companyUnitRepository = companyUnitRepository;
            _mapper = mapper;
        }

        [Route("nova-unidade")]
        public async Task<IActionResult> CreateUnits()
        {
            var companyUnitViewModel = await this.GetCompanies(new CompanyUnitViewModel());

            return View(companyUnitViewModel);
        }

        [HttpPut]
        [Route("nova-unidade")]
        public async Task<IActionResult> CreateUnits(CompanyUnitViewModel companyUnitViewModel)
        {
            if (!ModelState.IsValid) return View(companyUnitViewModel);

            var companyUnit = _mapper.Map<CompanyUnit>(companyUnitViewModel);
            await _companyUnitService.Add(companyUnit);

            if (!IsValidOperation()) return View(companyUnitViewModel);

            return RedirectToAction("Index", "Companies");
        }


        #region .: Private Methods :.
        private async Task<CompanyViewModel> GetCompanyWithUnits(Guid id)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetCompanyWithUnits(id));
        }

        private async Task<CompanyUnitViewModel> GetCompanies(CompanyUnitViewModel companyUnitViewModel)
        {
            companyUnitViewModel.Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());

            return companyUnitViewModel;
        }
        #endregion
    }
}
