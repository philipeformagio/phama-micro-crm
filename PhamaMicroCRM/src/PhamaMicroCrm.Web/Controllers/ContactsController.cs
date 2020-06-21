﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using PhamaMicroCrm.Web.ViewModels;

namespace PhamaMicroCrm.Web.Controllers
{
    public class ContactsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly ICompanyUnitRepository _companyUnitRepository;
        private readonly IContactService _contactService;
        public ContactsController(IMapper mapper,
                                  INotifier notifier,
                                  IContactService contactService,
                                  IContactRepository contactRepository,
                                  ICompanyUnitRepository companyUnitRepository) : base(notifier)
        {
            _contactRepository = contactRepository;
            _companyUnitRepository = companyUnitRepository;
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var contactsViewModel = _mapper.Map<IEnumerable<ContactViewModel>>(await _contactRepository.GetAll());
            return View(contactsViewModel);
        }

        [Route("novo-contato")]
        public async Task<IActionResult> Create()
        {
            var contactViewModel = await this.PopulateContactViewModel(new ContactViewModel());
            return View(contactViewModel);
        }

        [Route("novo-contato")]
        [HttpPost]
        public async Task<IActionResult> Create(ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid) return View(contactViewModel);

            var contact = _mapper.Map<Contact>(contactViewModel);
            await _contactService.Add(contact);

            if (!IsValidOperation()) return View(contactViewModel);

            return RedirectToAction(nameof(Index));
        }

        #region .: Private Methods :.
        private async Task<ContactViewModel> PopulateContactViewModel(ContactViewModel contactViewModel)
        {
            contactViewModel.CompanyUnits = _mapper.Map<IEnumerable<CompanyUnitViewModel>>(await _companyUnitRepository.GetAll());
            return contactViewModel;
        }
        #endregion
    }
}
