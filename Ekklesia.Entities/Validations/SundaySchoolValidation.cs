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
    public class SundaySchoolValidation: AbstractValidator<SundaySchoolDTO>
    {
        public SundaySchoolValidation()
        {
            var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
            var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);

            RuleFor(ss => ss.Date)
                .ExclusiveBetween(LowerBound, UpperBound)
                .WithMessage($"A data de uma escola dominical prescisa estar entre {LowerBound.ToString("M")} e {UpperBound.ToString("M")}.");

            RuleFor(ss => ss.NumberOfBibles).GreaterThanOrEqualTo(0).WithMessage("O número de biblias precisa ser maior ou igaul a zero.");

            RuleFor(ss => ss.Participants).NotEmpty().WithMessage("Uma escola dominical precisa ter ao menos um participante.");

            RuleFor(ss => ss.Teacher).NotNull().WithMessage("Uma escola dominical precisa ter um professor.");

            RuleFor(ss => ss.Theme).NotEmpty().WithMessage("Uma escola dominical precisa ter um tema.");

            RuleFor(ss => ss.Verse).NotEmpty().WithMessage("Uma escola dominical precisa ter um versículo.");

            RuleFor(ss=> ss.Visitants).GreaterThanOrEqualTo(0).WithMessage("O número de visitantes precisa ser maior ou igaul a zero.");
        }
    }
}