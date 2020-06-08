using System;

namespace PhamaMicroCrm.Model.Entities
{
    public class CompanyUnit : Entity
    {
        public Guid CompanyId { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public bool Active { get; set; }

        public Company Company { get; set; }
    }
}
