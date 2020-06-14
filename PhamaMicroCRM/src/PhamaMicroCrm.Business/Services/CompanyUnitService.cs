using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using PhamaMicroCrm.Model.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Business.Services
{
    public class CompanyUnitService : BaseService, ICompanyUnitService
    {
        private readonly ICompanyUnitRepository _companyUnitRepository;
        public CompanyUnitService(INotifier notifier,
                                  ICompanyUnitRepository companyUnitRepository) : base(notifier)
        {
            _companyUnitRepository = companyUnitRepository;
        }


        public async Task Add(CompanyUnit companyUnit)
        {
            if (!ExecuteValidation(new CompanyUnitValidation(), companyUnit)) return;

            if (_companyUnitRepository.Get(c => c.Name == companyUnit.Name).Result.Any())
            {
                Notify("Já existe essa unidade cadastrada com esse nome.");
                return;
            }

            await _companyUnitRepository.Add(companyUnit);
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CompanyUnit companyUnit)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _companyUnitRepository?.Dispose();
        }
    }
}
