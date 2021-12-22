using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class IncomeValidation : AbstractValidator<IncomeDTO>
    {
        public IncomeValidation()
        {
            var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
            var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);

            RuleFor(i => i.Date)
                .ExclusiveBetween(LowerBound, UpperBound)
                .WithMessage($"A data de uma receita prescisa estar entre {LowerBound.ToString("M")} e {UpperBound.ToString("M")}.");


            RuleFor(r => r.Value)
               .GreaterThan(0).WithMessage("Uma receita prescisa um valor maior que zero.");

            RuleFor(r => r.Type)
                .IsInEnum().WithMessage("Um receita precisa obrigatoriamente ter um tipo.");
        }

    }
}
