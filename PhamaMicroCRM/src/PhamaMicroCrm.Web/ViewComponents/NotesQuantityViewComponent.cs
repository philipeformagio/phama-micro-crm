using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Web.ViewComponents
{
    [ViewComponent(Name = "NotesQuantity")]
    public class NotesQuantityViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;
        public NotesQuantityViewComponent(IMapper mapper, 
                                          INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notesQuantityList = _mapper.Map<IEnumerable<QuantityNotesPerCompanyViewModel>>(await _noteRepository.GetQuantityNotesPerCompany());
            return View(notesQuantityList);
        }
    }
}
