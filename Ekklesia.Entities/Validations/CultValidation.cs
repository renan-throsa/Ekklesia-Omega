using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class CultValidation : AbstractValidator<CultDTO>
    {
        public CultValidation()
        {
            var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
            var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);

            RuleFor(c => c.Date)
                .ExclusiveBetween(LowerBound, UpperBound)
                .WithMessage($"A data de um culto prescisa estar entre {LowerBound.ToString("M")} e {UpperBound.ToString("M")}.");

            RuleFor(c => c.Convertions)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O número de conversões deve ser maior ou igual 0.");           


            RuleFor(c => c.KeyVerse)
                .NotEmpty()
                .WithMessage("O vérsiculo chave não pode estar vazio.");

            RuleFor(c => c.CultType)
                .IsInEnum()
                 .WithMessage("Um culto precisa obrigatoriamente ter um tipo.");

            RuleFor(c => c.NumberOfPeople)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Número de conversões deve ser maior ou igual 0.");

        }
    }
}
