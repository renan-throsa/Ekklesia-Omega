using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class ReunionValidation : AbstractValidator<ReunionDTO>
    {
        public ReunionValidation()
        {
            RuleFor(r => r.Date)
                 .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
                .WithMessage($"A data da reunião prescisa estar entre hoje e menos um mês atrás.");

            RuleFor(r => r.EndTime).GreaterThan(r => r.Date).WithMessage("A data de fim de uma reunião não pode ser menor que a data da reunião.");

            RuleFor(r => r.Participants).NotEmpty().WithMessage("Uma reunião precisa ter ao menos um participante.");

            RuleFor(r => r.Speaker).NotNull().WithMessage("Uma reuniãp precisa ter um pregador.");

            RuleFor(r => r.ReunionType).IsInEnum()
                .WithMessage("Uma reunião precisa obrigatoriamente ter um tipo.");

            RuleFor(r => r.Topic).NotEmpty().WithMessage("Uma reunião precisa ter obrigatoriamente um tópico.");
        }
    }
}
