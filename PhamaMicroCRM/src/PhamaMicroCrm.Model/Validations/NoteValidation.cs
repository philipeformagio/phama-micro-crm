using FluentValidation;
using PhamaMicroCrm.Model.Entities;

namespace PhamaMicroCrm.Model.Validations
{
    public class NoteValidation : AbstractValidator<Note>
    {
        public NoteValidation()
        {
            RuleFor(n => n.CompanyId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(n => n.Text)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 500).WithMessage("O campo {PropertyName} pode ter até 500 caracteres.");

            RuleFor(n => n.Title)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(4, 50).WithMessage("O campo {PropertyName} pode ter até 50 caracteres.");
        }
    }
}
