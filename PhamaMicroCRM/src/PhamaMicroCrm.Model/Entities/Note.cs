using System;

namespace PhamaMicroCrm.Model.Entities
{
    public class Note : Entity
    {
        public Guid CompanyId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }


        public Company Company { get; set; }
    }
}
