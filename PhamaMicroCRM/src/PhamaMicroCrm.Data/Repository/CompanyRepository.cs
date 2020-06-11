using Microsoft.EntityFrameworkCore;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public async Task<Company> GetCompanyWithUnits(Guid companyId)
        {
            return await Db.Companies.AsNoTracking()
                           .Include(c => c.CompanyUnits)
                           .FirstOrDefaultAsync(c => c.Id == companyId);
        }

        public async Task<IEnumerable<Company>> GetCompaniesWithUnits()
        {
            return await Db.Companies.AsNoTracking()
                           .Include(c => c.CompanyUnits)
                           .ToListAsync();
        }
    }
}
