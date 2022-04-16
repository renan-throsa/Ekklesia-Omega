using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class BaptismValidation : AbstractValidator<BaptismDTO>
    {
        public BaptismValidation()
        {
            var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
            var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);

            RuleFor(b => b.Date)
                .ExclusiveBetween(LowerBound, UpperBound)
                .WithMessage($"A data de batismo prescisa estar entre {LowerBound.ToString("M")} e {UpperBound.ToString("M")}.");

            RuleFor(b => b.Baptizer)
               .NotNull().WithMessage("Um batismo precisa ter um batizador.")
               .Must(responsable => !string.IsNullOrEmpty(responsable.Name) || !string.IsNullOrEmpty(responsable.Id))
              .WithMessage("Um batismo precisa ter um batizador.");

            RuleFor(b => b.Baptizeds)
                .NotEmpty().WithMessage("O batismo precisa ter ao menos um batizado.");


            RuleFor(b => b.Place)
                .NotEmpty().WithMessage("O lugar de batismos não pode ser vazio.");

        }
    }
}
