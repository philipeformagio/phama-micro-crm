using Microsoft.EntityFrameworkCore;
using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Data.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(PhamaMicroCrmContext context) : base(context) { }

        public async Task<IEnumerable<Contact>> GetContactsWithCompany()
        {
            return await Db.Contacts.AsNoTracking()
                                    .Include(c => c.CompanyUnit)
                                    .ThenInclude(cu => cu.Company)
                                    .ToListAsync();
        }

        public async Task<Contact> GetContactWithCompanyUnit(Guid contactId)
        {
            return await Db.Contacts.AsNoTracking()
                                    .Include(c => c.CompanyUnit)
                                    .FirstOrDefaultAsync(c => c.Id == contactId);
        }
    }
}
