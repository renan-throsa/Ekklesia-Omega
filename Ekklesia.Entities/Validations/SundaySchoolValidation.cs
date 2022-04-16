using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

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

            RuleFor(r => r.Teacher).NotNull().WithMessage("Uma escola dominical precisa ter um professor.");           

            RuleFor(r => r.Teacher.Name).NotEmpty().When(r => r.Teacher != null).WithMessage("Uma escola dominical precisa ter um professor válido.");

            RuleFor(r => r.Teacher.Id).NotEmpty().When(r => r.Teacher != null).WithMessage("Uma escola dominical precisa ter um professor válido.");

            RuleFor(ss => ss.Theme).NotEmpty().WithMessage("Uma escola dominical precisa ter um tema.");

            RuleFor(ss => ss.Verse).NotEmpty().WithMessage("Uma escola dominical precisa ter um versículo.");

            RuleFor(ss=> ss.Visitants).GreaterThanOrEqualTo(0).WithMessage("O número de visitantes precisa ser maior ou igaul a zero.");
        }
    }
}