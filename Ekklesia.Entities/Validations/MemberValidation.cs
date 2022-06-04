using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using FluentValidation;

namespace Ekklesia.Entities.Validations
{
    public class MemberValidation : AbstractValidator<MemberDTO>
    {
        public MemberValidation()
        {
            RuleSet(OperationType.Insert.ToString(), () =>
            {
                RuleFor(m => m.Id).Empty();

                RuleFor(m => m.Name).Matches(@"^[A-ZÀ-Ÿ][A-zÀ-ÿ']+\s([A-zÀ-ÿ']\s?)*[A-ZÀ-Ÿ][A-zÀ-ÿ']+$")
                .WithMessage("Um membro precisa ter um nome válido.");

                RuleFor(m => m.Phone).Matches(@"^[1-9]{2}[1-9]{4,5}[0-9]{4}$")
                    .WithMessage("O número de telefone deve ter exatamente 11 caracteres.");

                RuleFor(m => m.Role).NotNull().WithMessage("Um membro precisa ter um cargo.");

                RuleFor(m => m.Role).IsInEnum()
                    .WithMessage("Um membro precisa ter um cargo válido.");

            });

            RuleSet(OperationType.Update.ToString(), () =>
            {
                RuleFor(m => m.Id).NotEmpty();

                RuleFor(m => m.Name).Matches(@"^[A-ZÀ-Ÿ][A-zÀ-ÿ']+\s([A-zÀ-ÿ']\s?)*[A-ZÀ-Ÿ][A-zÀ-ÿ']+$")
                .WithMessage("Um membro precisa ter um nome válido.");

                RuleFor(m => m.Phone).Matches(@"^[1-9]{2}[1-9]{4,5}[0-9]{4}$")
                    .WithMessage("O número de telefone deve ter exatamente 11 caracteres.");

                RuleFor(m => m.Role).NotNull().WithMessage("Um membro precisa ter um cargo.");

                RuleFor(m => m.Role).IsInEnum()
                    .WithMessage("Um membro precisa obrigatoriamente ter um cargo.");

            });

            RuleSet(OperationType.Delete.ToString(), () =>
            {
                RuleFor(m => m.Id).NotEmpty();
            });

        }
    }
}
