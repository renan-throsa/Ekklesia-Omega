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
                .ExclusiveBetween(DateTime.Now.AddDays(-6), DateTime.Now.AddDays(1))
                .WithMessage($"Uma receita prescisa ter uma data entre hoje e 6 dias atrás");

            RuleFor(r => r.Value)
               .GreaterThan(0).WithMessage("Uma receita prescisa um valor maior que zero");

            RuleFor(r => r.Type)
                .IsInEnum().WithMessage("Um receita precisa obrigatoriamente ter um tipo.");
        }

    }
}
