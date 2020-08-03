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
        public string Title { get; set; }
        
        [Required(ErrorMessage = "O campo Anotação é obrigatório")]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<CompanyViewModel> Companies { get; set; }
    }
}
