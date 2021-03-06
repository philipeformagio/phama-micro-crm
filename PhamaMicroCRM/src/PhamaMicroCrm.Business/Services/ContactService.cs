﻿using PhamaMicroCrm.Business.Interfaces;
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
            if (!ExecuteValidation(new ContactValidation(), contact)) return;

            //if (_contactRepository.Get(c => c.))

            //    throw new NotImplementedException();

            await _contactRepository.Add(contact);
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Contact contact)
        {
            if (!ExecuteValidation(new ContactValidation(), contact)) return;

            await _contactRepository.Update(contact);
        }

        public void Dispose()
        {
            _contactRepository?.Dispose();
        }
    }
}
