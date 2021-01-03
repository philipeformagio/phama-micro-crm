using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using PhamaMicroCrm.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace PhamaMicroCrm.Web.Controllers
{
    public class NotesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly INoteRepository _noteRepository;
        private readonly INoteService _noteService;
        public NotesController(ICompanyRepository companyRepository,
                               INoteService noteService,
                               INoteRepository noteRepository,
                               IMapper mapper,
                               INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _noteService = noteService;
            _noteRepository = noteRepository;
        }

        [Route("anotacoes")]
        public async Task<IActionResult> Index()
        {
             //ViewBag.NotesPerCompany = _mapper.Map<IEnumerable<QuantityNotesPerCompanyViewModel>>(await _noteRepository.GetQuantityNotesPerCompany());

            return View();
        }

        [Route("nova-anotacao")]
        public async Task<IActionResult> Create()
        {
            var noteViewModel = await this.GetNotesViewModel(new NoteViewModel());
            return View(noteViewModel);
        }

        [Route("nova-anotacao")]
        [HttpPost]
        public async Task<IActionResult> Create(NoteViewModel noteViewModel)
        {
            noteViewModel.Companies = await this.GetAllCompaniesList();
            if (!ModelState.IsValid) return View(noteViewModel);

            var note = _mapper.Map<Note>(noteViewModel);
            note.CreatedAt = DateTime.Now;
            await _noteService.Add(note);

            if (!IsValidOperation()) return View(noteViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("detalhes-anotacao/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var noteViewModel = await this.GetNotesDetails(id.Value);
            if (noteViewModel == null) return NotFound();

            return View(noteViewModel);
        }

        [Route("editar-anotacao/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var noteViewModel = await this.GetNotesDetails(id.Value);
            noteViewModel = await this.GetNotesViewModel(noteViewModel);

            if (noteViewModel == null) return NotFound();

            return View(noteViewModel);
        }

        [HttpPost]
        [Route("editar-anotacao/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, NoteViewModel noteViewModel)
        {
            if (id != noteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(noteViewModel);

            var note = _mapper.Map<Note>(noteViewModel);
            await _noteService.Update(note);

            if (!IsValidOperation()) return View(noteViewModel);

            return RedirectToAction(nameof(Index));
        }


        #region .: API Calls :.
        public async Task<IActionResult> GetAll()
        {
            var results =  await _noteRepository.GetNotesAllWithCompany();
            var dataObj = results.Select(x => new
            {
                Id = x.Id,
                CompanyName = x.Company.Name,
                Title = x.Title,
                Text = x.Text.Substring(0, 12) + "..."
            });

            return Json(new { data = dataObj });
        }
        #endregion

        #region .: Private Methods :.
        private async Task<NoteViewModel> GetNotesViewModel(NoteViewModel noteViewModel)
        {
            noteViewModel.Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());

            return noteViewModel;
        }

        private async Task<IEnumerable<CompanyViewModel>> GetAllCompaniesList()
        {
            return _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());
        }

        private async Task<NoteViewModel> GetNotesDetails(Guid id)
        {
            return _mapper.Map<NoteViewModel>(await _noteRepository.GetNoteWithCompanyById(id));
        }
        #endregion
    }
}
