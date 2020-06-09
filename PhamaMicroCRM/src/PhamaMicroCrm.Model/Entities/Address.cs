using System;

namespace PhamaMicroCrm.Model.Entities
{
    public class Address : Entity
    {
        public Guid CompanyUnitId { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public CompanyUnit CompanyUnit { get; set; }
    }
}
