using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class MeetingValidation : AbstractValidator<MeetingDTO>
    {
        public MeetingValidation()
        {
            var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
            var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);

            RuleFor(m => m.Date)
                .ExclusiveBetween(LowerBound, UpperBound)
                .WithMessage($"A data de um encontro prescisa estar entre {LowerBound.ToString("M")} e {UpperBound.ToString("M")}.");                     

            RuleFor(r => r.Speaker)
               .NotNull().WithMessage("Um encontro precisa ter um orador.")
               .Must(speaker => !string.IsNullOrEmpty(speaker.Name) || !string.IsNullOrEmpty(speaker.Id))
              .WithMessage("Um encontro precisa ter um orador.");

            RuleFor(m => m.Participants).NotEmpty().WithMessage("A reunião precisa ter ao menos um participante.");            
        }
    }
}
