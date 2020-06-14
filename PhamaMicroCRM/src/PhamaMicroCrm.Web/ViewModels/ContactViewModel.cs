﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhamaMicroCrm.Web.ViewModels
{
    public class ContactViewModel
    {
        public System.Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome da Unidade")]
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }

        public CompanyUnitViewModel CompanyUnit { get; set; }
    }
}