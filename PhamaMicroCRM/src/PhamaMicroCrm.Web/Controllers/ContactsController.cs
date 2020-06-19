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
    public class ContactsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
        private readonly IContactService _contactService;
        public ContactsController(INotifier notifier,
                                  IContactService contactService,
                                  IContactRepository contactRepository) : base(notifier)
        {
            _contactRepository = contactRepository;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contactsViewModel = _contactRepository.GetAll();
            return View(contactsViewModel);
        }

        [Route("novo-contato")]
        public IActionResult Create()
        {
            return View();
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
    }
}
