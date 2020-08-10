using PhamaMicroCrm.Data.ResultSets;
using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Data.Interfaces
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<IEnumerable<Note>> GetNotesAllWithCompany();

        Task<Note> GetNoteWithCompanyById(Guid id);

        Task<IEnumerable<QuantityNotesPerCompany>> GetQuantityNotesPerCompany();
    }
}
