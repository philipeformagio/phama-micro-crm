using System.Collections.Generic;

namespace PhamaMicroCrm.Model.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Field { get; set; }
        public bool Active { get; set; }

        public IEnumerable<CompanyUnit> CompanyUnits { get; set; }
    }
}
