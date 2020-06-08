using System;

namespace PhamaMicroCrm.Model.Entities
{
    public class Contact : Entity
    {
        public Guid CompanyUnitId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public CompanyUnit CompanyUnit { get; set; }
    }
}
