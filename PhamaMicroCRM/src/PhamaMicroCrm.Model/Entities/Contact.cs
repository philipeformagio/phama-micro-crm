using System;

namespace PhamaMicroCrm.Model.Entities
{
    public class Contact : Entity
    {
        public Guid CompanyUnitId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }
        public DateTime CreatedAt { get; set; }

        public CompanyUnit CompanyUnit { get; set; }
    }
}
