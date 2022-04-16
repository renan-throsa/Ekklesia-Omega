using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class ExpenseValidation : AbstractValidator<ExpenseDTO>
    {
        public ExpenseValidation()
        {
            RuleFor(e => e.Date)
                .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
                .WithMessage($"Uma despesa prescisa estar entre hoje e menos um mês atrás.");

            RuleFor(e => e.Responsable).NotNull().WithMessage("Uma despesa precisa ter um responsável.");

            RuleFor(r => r.Responsable.Name).NotEmpty().When(r => r.Responsable != null).WithMessage("Uma despesa precisa ter um válido.");

            RuleFor(r => r.Responsable.Id).NotEmpty().When(r => r.Responsable != null).WithMessage("Uma despesa precisa ter um válido.");

            RuleFor(e => e.Value)
               .GreaterThan(0).WithMessage("Uma despesa prescisa um valor maior que zero");

            RuleFor(e => e.Description)
               .NotEmpty().WithMessage("A descrição de uma despesa não pode ser vazia.");
        }
    }
}
