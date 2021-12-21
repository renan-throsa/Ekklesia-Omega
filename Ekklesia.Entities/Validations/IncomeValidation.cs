using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class IncomeValidation : AbstractValidator<IncomeDTO>
    {
        public IncomeValidation()
        {
            RuleFor(r => r.Date)
                .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
                .WithMessage($"A data de uma receita prescisa entre hoje menos um mês antes.");

            RuleFor(r => r.Value)
               .GreaterThan(0).WithMessage("Uma receita prescisa um valor maior que zero.");

            RuleFor(r => r.Type)
                .IsInEnum().WithMessage("Um receita precisa obrigatoriamente ter um tipo.");
        }

    }
}
