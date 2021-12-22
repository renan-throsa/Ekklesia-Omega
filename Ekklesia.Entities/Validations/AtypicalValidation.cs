using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class AtypicalValidation : AbstractValidator<AtypicalDTO>
    {
        public AtypicalValidation()
        {
            var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
            var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);

            RuleFor(a => a.Date)
                .ExclusiveBetween(LowerBound, UpperBound)
                .WithMessage($"Um evento atípico prescisa estar entre {LowerBound.ToString("M")} e {UpperBound.ToString("M")}.");

            RuleFor(a => a.Description).NotEmpty().WithMessage("Um evento atípico prescisa ter uma descrição.");
        }
    }
}