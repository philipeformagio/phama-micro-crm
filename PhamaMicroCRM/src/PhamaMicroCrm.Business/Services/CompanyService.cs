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

            if (_companyRepository.Get(c => c.Name == company.Name).Result.Any())
            {
                Notify("Já existe uma empresa cadastrada com esse nome.");
                return;
            }

            await _companyRepository.Add(company);
        }

        public async Task Update(Company company)
        {
            if (!ExecuteValidation(new CompanyValidation(), company)) return;

            //if (_companyRepository.Get(c => c.Name == company.Name).Result.Any())
            //{
            //    Notify("Já existe uma empresa cadastrada com esse nome.");
            //    return;
            //}

            await _companyRepository.Update(company);
        }

        public async Task Remove(Guid id)
        {
            if ((await _companyRepository.GetCompanyWithUnits(id)).CompanyUnits.Any())
            {
                Notify("Não poderá excluir essa empresa, pois ela possuí unidade(s) atrelada(s) à ela.");
                return;
            }

            await _companyRepository.Remove(id);
        }

        public void Dispose()
        {
            _companyRepository?.Dispose();
        }
    }
}
