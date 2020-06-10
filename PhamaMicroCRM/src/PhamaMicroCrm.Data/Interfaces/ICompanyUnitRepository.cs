using PhamaMicroCrm.Model.Entities;
using System;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Data.Interfaces
{
    public interface ICompanyUnitRepository : IRepository<CompanyUnit>
    {
        Task<CompanyUnit> GetCompanyUnitWithAddress(Guid companyUnitId);
    }
}
