using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhamaMicroCrm.Web.ViewModels
{
    public class NoteViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Empresa")]
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "O campo Anotação é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        [DisplayName("Anotação")]
        public string Text { get; set; }

        [DisplayName("Criado em:")]
        public DateTime CreatedAt { get; set; }

        public IEnumerable<CompanyViewModel> Companies { get; set; }

        public CompanyViewModel Company { get; set; }
    }
}
