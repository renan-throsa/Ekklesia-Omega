using Ekklesia.Domain.Contants;
using Ekklesia.Domain.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Application.Validations
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
