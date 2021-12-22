using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            RuleFor(m => m.Speaker).NotNull().WithMessage("A reunião precisa ter um pregador.");
            RuleFor(m => m.Participants).NotEmpty().WithMessage("A reunião precisa ter ao menos um participante.");            
        }
    }
}
