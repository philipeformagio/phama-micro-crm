using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Data.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetCompanyWithUnitsAndWithAddress(Guid companyId);

        Task<Company> GetCompanyWithUnits(Guid companyId);

        Task<IEnumerable<Company>> GetCompaniesWithUnits();
    }
}
