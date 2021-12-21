using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class AtypicalValidation : AbstractValidator<AtypicalDTO>
    {
        public AtypicalValidation()
        {
            RuleFor(a => a.Date)
                .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
                .WithMessage($"Um evento atípico prescisa estar entre hoje e menos um mês atrás.");

            RuleFor(a => a.Description).NotEmpty().WithMessage("Um evento atípico prescisa ter uma descrição");
        }
    }
}