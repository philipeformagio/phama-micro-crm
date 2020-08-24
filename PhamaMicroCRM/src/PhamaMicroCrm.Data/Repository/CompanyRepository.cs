using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(PhamaMicroCrmContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task<Company> GetCompanyWithUnitsAndWithAddress(Guid companyId)
        {
            return await Db.Companies.AsNoTracking()
                           .Include(c => c.CompanyUnits)
                           .ThenInclude(cu => cu.Address)
                           .FirstOrDefaultAsync(c => c.Id == companyId);
        }

        public async Task<IEnumerable<Company>> GetCompaniesWithUnits()
        {
            return await Db.Companies.AsNoTracking()
                           .Include(c => c.CompanyUnits)
                           .ToListAsync();
        }

        public async Task<Company> GetCompanyWithUnits(Guid companyId)
        {
            return await Db.Companies.AsNoTracking()
                           .Include(c => c.CompanyUnits)                           
                           .FirstOrDefaultAsync(c => c.Id == companyId);
        }
    }
}
