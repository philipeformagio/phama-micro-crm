using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Data.ResultSets;
using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Data.Repository
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(PhamaMicroCrmContext context, IConfiguration configuration) : base(context, configuration) { }

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

        public async Task<IEnumerable<QuantityNotesPerCompany>> GetQuantityNotesPerCompany()
        {
            IEnumerable<QuantityNotesPerCompany> result;

            using (SqlConnection conection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                result = await conection.QueryAsync<QuantityNotesPerCompany>(
                    "SELECT Note.CompanyId, Comp.Name, COUNT(Note.CompanyId) AS 'Counted' " +
                    "FROM Notes AS Note INNER JOIN Companies AS Comp ON Note.CompanyId = Comp.Id " +
                    "GROUP BY Note.CompanyId, Comp.Name");
            }

            return result.ToList();
        }
    }
}
