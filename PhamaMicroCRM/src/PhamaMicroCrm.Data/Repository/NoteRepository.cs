using Microsoft.EntityFrameworkCore;
using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Data.Repository
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(PhamaMicroCrmContext context) : base(context) { }

        public async Task<IEnumerable<Note>> GetNotesAllWithCompany()
        {
            return await Db.Notes.AsNoTracking()
                           .Include(x => x.Company)
                           .ToListAsync();
        }

        public async Task<Note> GetNoteWithCompanyById(Guid id)
        {
            return await Db.Notes.AsNoTracking()
                           .Include(x => x.Company)
                           .Where(x => x.Id == id)
                           .FirstOrDefaultAsync();
        }
    }
}
