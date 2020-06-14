using Microsoft.EntityFrameworkCore;
using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using System;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Data.Repository
{
    public class CompanyUnitRepository : Repository<CompanyUnit>, ICompanyUnitRepository
    {
        public CompanyUnitRepository(PhamaMicroCrmContext context) : base(context) { }

        public async Task<CompanyUnit> GetCompanyUnitWithAddress(Guid companyUnitId)
        {
            return await Db.CompanyUnits.AsNoTracking()
                           .Include(cu => cu.Address)
                           .FirstOrDefaultAsync(cu => cu.CompanyId == companyUnitId);
        }
    }
}
