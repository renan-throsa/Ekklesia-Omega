using Ekklesia.Domain.Contants;
using Ekklesia.Domain.DTOs;
using FluentValidation;

namespace Ekklesia.Application.Validations
{
    public class SundaySchoolValidation : AbstractValidator<SundaySchoolDTO>
    {
        public SundaySchoolValidation()
        {
            var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
            var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);


            RuleFor(ss => ss.NumberOfBibles).GreaterThanOrEqualTo(0).WithMessage("O número de biblias precisa ser maior ou igaul a zero.");

            RuleFor(ss => ss.Theme).NotEmpty().WithMessage("Uma escola dominical precisa ter um tema.");

            RuleFor(ss => ss.Verse).NotEmpty().WithMessage("Uma escola dominical precisa ter um versículo.");

            RuleFor(ss => ss.Visitants).GreaterThanOrEqualTo(0).WithMessage("O número de visitantes precisa ser maior ou igaul a zero.");
        }
    }
}