using AutoMapper;
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
    public class CompaniesController : BaseController
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompaniesController(IMapper mapper,
                                   ICompanyRepository companyRepository,
                                   ICompanyService companyService,
                                   INotifier notifier) : base(notifier)
        {
            _companyRepository = companyRepository;
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var companies = await _companyRepository.GetAll();
            var companyViewModel = _mapper.Map<IEnumerable<CompanyViewModel>>(companies);

            return View(companyViewModel);
        }

        [Route("nova-empresa")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("nova-empresa")]
        [HttpPost]
        public async Task<IActionResult> Create(CompanyViewModel companyViewModel)
        {
            if (!ModelState.IsValid) return View(companyViewModel);

            var company = _mapper.Map<Company>(companyViewModel);
            await _companyService.Add(company);

            if (!IsValidOperation()) return View(companyViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("nova-unidade")]
        public async Task<IActionResult> CreateUnits()
        {
            var companyUnitViewModel = await this.GetCompanies(new CompanyUnitViewModel());

            return View(companyUnitViewModel);
        }

        [Route("detalhes-empresa/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var companyViewModel = await this.GetCompanyWithUnits(id.Value);
            if (companyViewModel == null) return NotFound();

            return View(companyViewModel);
        }

        [Route("editar-empresa/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var companyViewModel = await this.GetCompanyWithUnits(id.Value);

            if (companyViewModel == null) return NotFound();

            return View(companyViewModel);
        }

        [HttpPost]
        [Route("editar-empresa/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, CompanyViewModel companyViewModel)
        {
            if (id != companyViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(companyViewModel);

            var company = _mapper.Map<Company>(companyViewModel);
            await _companyRepository.Updade(company);

            if (!IsValidOperation()) return View(companyViewModel);

            return RedirectToAction(nameof(Index));
        }

        //[HttpPut]
        //[Route("nova-unidade")]
        //public async Task<IActionResult> CreateUnits(CompanyViewModel companyViewModel)
        //{
        //    if (!ModelState.IsValid) return View(companyViewModel);

        //    return View();
        //}




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
