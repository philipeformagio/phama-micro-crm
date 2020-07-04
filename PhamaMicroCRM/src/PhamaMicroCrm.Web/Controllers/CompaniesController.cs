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

        [Route("lista-de-empresas")]
        public IActionResult Index()
        {
            return View();
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

        [Route("detalhes-empresa/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var companyViewModel = await this.GetCompanyWithUnitsAndWithAddress(id.Value);
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
            await _companyService.Update(company);

            if (!IsValidOperation()) return View(companyViewModel);

            return RedirectToAction(nameof(Index));
        }


        #region .: API Calls :.

        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _companyRepository.GetAll() });
        }

        [HttpDelete]
        [Route("deletar-empresa/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _companyService.Remove(id);
            }
            catch (Exception)
            {

                throw;
            }

            //if (bookFromDb == null)
            //{
            //    return Json(new { success = false, message = "Error while deleting" });
            //}

            //_db.Books.Remove(bookFromDb);
            //await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion


        #region .: Private Methods :.
        private async Task<CompanyViewModel> GetCompanyWithUnitsAndWithAddress(Guid id)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetCompanyWithUnitsAndWithAddress(id));
        }

        private async Task<CompanyViewModel> GetCompanyWithUnits(Guid id)
        {
            return _mapper.Map<CompanyViewModel>(await _companyRepository.GetCompanyWithUnits(id));
        }
        #endregion
    }
}
