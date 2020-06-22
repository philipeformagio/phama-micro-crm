using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhamaMicroCrm.Web.ViewModels
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Unidade")]
        public Guid CompanyUnitId { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Telefone 1")]
        public string Phone_1 { get; set; }

        [DisplayName("Telefone 2")]
        public string Phone_2 { get; set; }
        public DateTime CreatedAt { get; set; }

        public CompanyUnitViewModel CompanyUnit { get; set; }

        public IEnumerable<CompanyUnitViewModel> CompanyUnits { get; set; }
    }
}