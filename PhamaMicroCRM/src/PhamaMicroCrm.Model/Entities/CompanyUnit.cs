using System;
using System.Collections.Generic;

namespace PhamaMicroCrm.Model.Entities
{
    public class CompanyUnit : Entity
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }
        public string Phone_3 { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }

        public Company Company { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
    }
}
