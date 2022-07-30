using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekkleisa.Business.Implementation.Validations
{
    public class IncomeValidation : AbstractValidator<IncomeDTO>
    {
        public IncomeValidation()
        {
            RuleFor(r => r.Type)
                .IsInEnum().WithMessage("Um receita precisa obrigatoriamente ter um tipo.");

            RuleFor(r => r.Observation).MaximumLength(250).WithMessage("Obeservação não pode exceder 250 caracteres");
        }

    }
}
