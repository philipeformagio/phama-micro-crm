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
    public class CompanyUnitRepository : Repository<CompanyUnit>, ICompanyUnitRepository
    {
        public CompanyUnitRepository(PhamaMicroCrmContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task<IEnumerable<CompanyUnit>> GetAllCompanyUnitsWithCompanies()
        {
            return await Db.CompanyUnits.AsNoTracking()
                           .Include(cu => cu.Company)
                           .ToListAsync();
        }

        public async Task<CompanyUnit> GetCompanyUnitWithAddress(Guid companyUnitId)
        {
            return await Db.CompanyUnits.AsNoTracking()
                           .Include(cu => cu.Address)
                           .FirstOrDefaultAsync(cu => cu.Id == companyUnitId);
        }
    }
}
