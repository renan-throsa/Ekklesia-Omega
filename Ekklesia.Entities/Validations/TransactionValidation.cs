using Ekklesia.Entities.DTOs;
using FluentValidation;
using System;

namespace Ekklesia.Entities.Validations
{
    public class TransactionValidation : AbstractValidator<TransactionDTO>
    {
        public TransactionValidation()
        {            

            RuleFor(x => x.Date)
               .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
               .WithMessage($"Uma despesa prescisa estar entre hoje e menos um mês atrás.");

            RuleFor(x => x.Value)
               .GreaterThan(0).WithMessage("Uma despesa prescisa um valor maior que zero");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Um transação precisa obrigatoriamente ter um tipo.");
            
        }
    }
}
