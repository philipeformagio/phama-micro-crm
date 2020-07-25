using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using PhamaMicroCrm.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Web.Controllers
{
    [Authorize]
    [Authorize(Roles = "User")]
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

        [Route("lista-de-unidades")]
        public async Task<IActionResult> Index()
        {
            var companiesUnits = await _companyUnitRepository.GetAllCompanyUnitsWithCompanies();
            var companyUnitsViewModel = _mapper.Map<IEnumerable<CompanyUnitViewModel>>(companiesUnits);

            return View(companyUnitsViewModel);
        }

        [Route("unidades/nova-unidade")]
        public async Task<IActionResult> Create()
        {
            var companyUnitViewModel = await this.GetCompanies(new CompanyUnitViewModel());

            return View(companyUnitViewModel);
        }

        [HttpPost]
        [Route("unidades/nova-unidade")]
        public async Task<IActionResult> Create(CompanyUnitViewModel companyUnitViewModel)
        {
            companyUnitViewModel.Companies = await this.GetAllCompaniesList();
            if (!ModelState.IsValid) return View(companyUnitViewModel);

            var companyUnit = _mapper.Map<CompanyUnit>(companyUnitViewModel);
            await _companyUnitService.Add(companyUnit);

            if (!IsValidOperation()) return View(companyUnitViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("detalhes-unidade/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var companyViewModel = await _companyUnitRepository.GetCompanyUnitWithAddress(id.Value);
            if (companyViewModel == null) return NotFound();

            return View(companyViewModel);
        }

        [Route("editar-unidade/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var companyUnitViewModel = _mapper.Map<CompanyUnitViewModel>(await this.GetCompanyUnitWithCompanies(id.Value));
            if (companyUnitViewModel == null) return NotFound();

            return View(companyUnitViewModel);
        }

        [Route("editar-unidade/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, CompanyUnitViewModel companyUnitViewModel)
        {
            if (id != companyUnitViewModel.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                companyUnitViewModel.Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());
                return View(companyUnitViewModel);
            }

            var companyUnit = _mapper.Map<CompanyUnit>(companyUnitViewModel);
            await _companyUnitService.Update(companyUnit);

            if (!IsValidOperation()) return View(companyUnitViewModel);

            return RedirectToAction(nameof(Index));
        }


        #region .: Private Methods :.
        private async Task<CompanyUnitViewModel> GetCompanyUnitWithCompanies(Guid id)
        {
            var companyUnit = await _companyUnitRepository.GetCompanyUnitWithAddress(id);
            var companyUnitViewModel = _mapper.Map<CompanyUnitViewModel>(companyUnit);
            companyUnitViewModel.Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());

            return companyUnitViewModel;

        }

        private async Task<CompanyUnitViewModel> GetCompanies(CompanyUnitViewModel companyUnitViewModel)
        {
            companyUnitViewModel.Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());

            return companyUnitViewModel;
        }

        private async Task<IEnumerable<CompanyViewModel>> GetAllCompaniesList()
        {
            return _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());
        }
        #endregion
    }
}
