using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class CultValidation : AbstractValidator<CultDTO>
    {
        public CultValidation()
        {
            RuleFor(c => c.Convertions)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Número de conversões deve ser maior ou igual 0.");

            RuleFor(c => c.Date)
                .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
                .WithMessage($"A data de um culto prescisa entre hoje e menos um mês antes.");


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
