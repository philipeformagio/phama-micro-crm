using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;

namespace PhamaMicroCrm.Data.Repository
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(PhamaMicroCrmContext context) : base(context) { }
    }
}
