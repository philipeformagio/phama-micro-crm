﻿using FluentValidation;
using PhamaMicroCrm.Model.Entities;

namespace PhamaMicroCrm.Model.Validations
{
    public class CompanyValidation : AbstractValidator<Company>
    {
        public CompanyValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
