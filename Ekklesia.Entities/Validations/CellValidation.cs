using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class CellValidation : AbstractValidator<CellDTO>
    {
        public CellValidation()
        {
            RuleFor(a => a.Date)
               .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
               .WithMessage($"Um evento atípico prescisa estar entre hoje e menos um mês atrás.");

            RuleFor(c => c.Convertions)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Número de conversões deve ser maior ou igual 0.");
        }
    }
}
