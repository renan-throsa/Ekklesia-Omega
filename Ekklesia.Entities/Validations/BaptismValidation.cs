using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.Validations
{
    public class BaptismValidation : AbstractValidator<BaptismDTO>
    {
        public BaptismValidation()
        {
            RuleFor(b => b.Baptizeds)               
                .NotEmpty().WithMessage("O batismo precisa ter ao menos um batizado.");

            RuleFor(b => b.Date)
                .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
                .WithMessage($"A data de batismo prescisa estar entre hoje e menos um mês atrás.");

            RuleFor(b=> b.Place)
                .NotEmpty().WithMessage("O lugar de batismos não pode ser vazio.");

        }
    }
}
