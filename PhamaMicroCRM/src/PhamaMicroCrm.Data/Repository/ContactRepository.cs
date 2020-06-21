using PhamaMicroCrm.Data.Context;
using PhamaMicroCrm.Data.Interfaces;
using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhamaMicroCrm.Data.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(PhamaMicroCrmContext context) : base(context) { }


    }
}
