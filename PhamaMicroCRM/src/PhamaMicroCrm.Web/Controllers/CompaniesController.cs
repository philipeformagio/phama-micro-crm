using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using PhamaMicroCrm.Web.ViewModels;
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

            return RedirectToAction("Index");
        }
    }
}
