using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class CellValidation : AbstractValidator<CellDTO>
    {
        public CellValidation()
        {
            var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
            var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);

            RuleFor(c => c.Date)
                .ExclusiveBetween(LowerBound, UpperBound)
                .WithMessage($"A data de uma célula prescisa estar entre {LowerBound.ToString("M")} e {UpperBound.ToString("M")}.");
              

            RuleFor(c => c.NumberOfConvertions)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Número de conversões deve ser maior ou igual 0.");
        }
    }
}
