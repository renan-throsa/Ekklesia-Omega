using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class ReunionValidation : AbstractValidator<ReunionDTO>
    {
        public ReunionValidation()
        {
            var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
            var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);

            RuleFor(r => r.Date)
                .ExclusiveBetween(LowerBound, UpperBound)
                .WithMessage($"A data da reunião prescisa estar entre {LowerBound.ToString("M")} e {UpperBound.ToString("M")}.");

            RuleFor(r => r.EndTime).GreaterThan(r => r.Date).WithMessage("A data de fim de uma reunião não pode ser menor que a data da reunião.");

            RuleFor(r => r.Participants).NotEmpty().WithMessage("Uma reunião precisa ter ao menos um participante.");

            RuleFor(r => r.Speaker).NotNull().WithMessage("Uma reunião precisa ter um pregador.");

            RuleFor(r => r.Speaker.Name).NotEmpty().When(r => r.Speaker != null).WithMessage("Uma reunião precisa ter um pregador válido.");

            RuleFor(r => r.Speaker.Id).NotEmpty().When(r => r.Speaker != null).WithMessage("Uma reunião precisa ter um pregador válido.");

            RuleFor(r => r.ReunionType).IsInEnum()
                .WithMessage("Uma reunião precisa obrigatoriamente ter um tipo.");

            RuleFor(r => r.Topic).NotEmpty().WithMessage("Uma reunião precisa ter obrigatoriamente um tópico.");
        }
    }
}
