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
            RuleFor(m => m.Date)
                .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
                .WithMessage($"A data de uma reunião prescisa estar entre hoje e menos um mês atrás.");

            RuleFor(m => m.Speaker).NotNull().WithMessage("A reunião precisa ter um pregador");
            RuleFor(m => m.Participants).NotEmpty().WithMessage("A reunião precisa ter ao menos um participante");            
        }
    }
}
