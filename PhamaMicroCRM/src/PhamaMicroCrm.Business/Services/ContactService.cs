using PhamaMicroCrm.Business.Interfaces;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using PhamaMicroCrm.Model.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Business.Services
{
    public class ContactService : BaseService, IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(INotifier notifier,
                              IContactRepository contactRepository) : base(notifier)
        {
            _contactRepository = contactRepository;
        }


        public async Task Add(Contact contact)
        {
            //if (!ExecuteValidation(new ContactValidation(), contact)) return;

            //if(_contactRepository.Get(c => c.))

            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
