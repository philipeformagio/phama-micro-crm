using System;

namespace PhamaMicroCrm.Data.ResultSets
{
    public class QuantityNotesPerCompany
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public int Counted { get; set; }
    }
}
