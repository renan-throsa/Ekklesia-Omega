using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using FluentValidation;
using System;

namespace Ekkleisa.Business.Implementation.Validations
{
    public class TransactionValidation : AbstractValidator<TransactionDTO>
    {
        public TransactionValidation()
        {
            #region Insertion
            RuleSet(OperationType.Insert.ToString(), () =>
            {
                RuleFor(m => m.Id).Empty().WithMessage("Não é possível inserir uma transação que já possua um id.");

                RuleFor(x => x.Date)
               .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
               .WithMessage($"Uma transação prescisa estar entre hoje e menos um mês atrás.");

                RuleFor(x => x.Amount)
                   .GreaterThan(0).WithMessage("Uma transação prescisa um valor maior que zero");

                RuleFor(x => x.Type)
                    .IsInEnum().WithMessage("Uma transação precisa obrigatoriamente ter um tipo.");

                RuleFor(e => e.Description)
                    .MaximumLength(250).WithMessage("Descrição não pode exceder 250 caracteres")
                    .NotEmpty().When(x => x.Type == TransactionType.DESPESA).WithMessage("A descrição de uma transação não pode ser vazia.");


                RuleFor(e => e.Responsable)
                .NotNull()
                .When(x => x.Type == TransactionType.DESPESA)
                .WithMessage("Uma despesa precisa ter um responsável.");

                RuleFor(r => r.Responsable.Name)
                .NotEmpty()
                .When(x => x.Type == TransactionType.DESPESA)
                .When(r => r.Responsable != null)
                .WithMessage("Uma despesa precisa ter um reponsável válido.");

                RuleFor(r => r.Responsable.Id)
                .NotEmpty()
                .When(x => x.Type == TransactionType.DESPESA)
                .When(r => r.Responsable != null)
                .WithMessage("Uma despesa precisa ter um reponsável válido.");

            });
            #endregion

            #region Update
            RuleSet(OperationType.Update.ToString(), () =>
            {
                RuleFor(m => m.Id).NotEmpty().WithMessage("Não é possível atualizar uma trassação que não possua um id.");

                RuleFor(x => x.Date)
               .ExclusiveBetween(DateTime.Now.AddMonths(-1), DateTime.Now.AddDays(1))
               .WithMessage($"Uma despesa prescisa estar entre hoje e menos um mês atrás.");

                RuleFor(x => x.Amount)
                   .GreaterThan(0).WithMessage("Uma despesa prescisa um valor maior que zero");


                RuleFor(x => x.Type)
                    .IsInEnum().WithMessage("Um transação precisa obrigatoriamente ter um tipo.");

                RuleFor(e => e.Description).MaximumLength(250).WithMessage("Descrição não pode exceder 250 caracteres")
                   .NotEmpty().WithMessage("A descrição de uma despesa não pode ser vazia.");


                RuleFor(e => e.Responsable)
                .NotNull()
                .When(x => x.Type == TransactionType.DESPESA)
                .WithMessage("Uma despesa precisa ter um responsável.");

                RuleFor(r => r.Responsable.Name)
                .NotEmpty()
                .When(x => x.Type == TransactionType.DESPESA)
                .When(r => r.Responsable != null)
                .WithMessage("Uma despesa precisa ter um nome de reponsável válido.");

                RuleFor(r => r.Responsable.Id)
                .NotEmpty()
                .When(x => x.Type == TransactionType.DESPESA)
                .When(r => r.Responsable != null)
                .WithMessage("Uma despesa precisa ter um id de reponsável válido.");

            });
            #endregion
        }
    }
}
