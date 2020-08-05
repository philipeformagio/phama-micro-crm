using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using PhamaMicroCrm.Model.Validations;
using System;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Business.Services
{
    public class NoteService : BaseService, INoteService
    {
        private readonly INoteRepository _noteRepository;
        public NoteService(INotifier notifier,
                           INoteRepository noteRepository) : base(notifier)
        {
            _noteRepository = noteRepository;
        }

        public async Task Add(Note note)
        {
            if (!ExecuteValidation(new NoteValidation(), note)) return;

            await _noteRepository.Add(note);
        }        

        public Task Remove(Note note)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Note note)
        {
            if (!ExecuteValidation(new NoteValidation(), note)) return;

            //if (_companyRepository.Get(c => c.Name == company.Name).Result.Any())
            //{
            //    Notify("Já existe uma empresa cadastrada com esse nome.");
            //    return;
            //}

            await _noteRepository.Update(note);
        }

        public void Dispose()
        {
            _noteRepository?.Dispose();
        }
    }
}
