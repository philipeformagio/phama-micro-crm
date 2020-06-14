using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using PhamaMicroCrm.Model.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Business.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(INotifier notifier,
                              ICompanyRepository companyRepository) : base(notifier)
        {
            _companyRepository = companyRepository;
        }


        public async Task Add(Company company)
        {
            if (!ExecuteValidation(new CompanyValidation(), company)) return;

            if(_companyRepository.Get(c => c.Name == company.Name).Result.Any())
            {
                Notify("Já existe uma empresa cadastrada com esse nome.");
                return;
            }

            await _companyRepository.Add(company);
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Company company)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _companyRepository?.Dispose();
        }
    }
}
