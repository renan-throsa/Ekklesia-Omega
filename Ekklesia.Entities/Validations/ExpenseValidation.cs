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
                .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(1))
                .WithMessage($"Uma despeza prescisa ter uma data do mês de {DateTime.Now.ToString("MMMM")}");

            RuleFor(e => e.Value)
               .GreaterThan(0).WithMessage("Uma receita prescisa um valor maior que zero");

            RuleFor(e => e.Description)
               .NotEmpty().WithMessage("Uma receita prescisa um valor maior que zero");
        }
    }
}
