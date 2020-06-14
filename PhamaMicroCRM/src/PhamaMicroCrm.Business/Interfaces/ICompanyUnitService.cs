using PhamaMicroCrm.Model.Entities;
using System;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Business.Interfaces
{
    public interface ICompanyUnitService : IDisposable
    {
        Task Add(CompanyUnit companyUnit);
        Task Update(CompanyUnit companyUnit);
        Task Remove(Guid id);
    }
}
