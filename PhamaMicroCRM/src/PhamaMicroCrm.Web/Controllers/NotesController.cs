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
    public class NotesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        public NotesController(ICompanyRepository companyRepository,
                               IMapper mapper,
                               INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        [Route("anotacoes")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("nova-anotacao")]
        public async Task<IActionResult> Create()
        {
            var noteViewModel = await this.GetNotesViewModel(new NoteViewModel());
            return View(noteViewModel);
        }

        //[Route("nova-anotacao")]
        //[HttpPost]
        //public async Task<IActionResult> Create(NoteViewModel noteViewModel)
        //{
        //    if (!ModelState.IsValid) return View(noteViewModel);

        //    var note = _mapper.Map<Note>(noteViewModel);
        //    await _

        //}

        #region .: Private Methods :.
        private async Task<NoteViewModel> GetNotesViewModel(NoteViewModel noteViewModel)
        {
            noteViewModel.Companies = _mapper.Map<IEnumerable<CompanyViewModel>>(await _companyRepository.GetAll());

            return noteViewModel;
        }
        #endregion
    }
}
