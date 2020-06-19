using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhamaMicroCrm.Web.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public Guid CompanyUnitId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }
        public DateTime CreatedAt { get; set; }

        //public CompanyUnitViewModel CompanyUnit { get; set; }
    }
}