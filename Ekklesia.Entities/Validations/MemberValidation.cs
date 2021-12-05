using Ekklesia.Entities.DTOs;
using FluentValidation;

namespace Ekklesia.Entities.Validations
{
    public class MemberValidation : AbstractValidator<MemberDTO>
    {
        public MemberValidation()
        {
            RuleFor(m => m.Name).Matches(@"^[A-ZÀ-Ÿ][A-zÀ-ÿ']+\s([A-zÀ-ÿ']\s?)*[A-ZÀ-Ÿ][A-zÀ-ÿ']+$")
                .WithMessage("Um membro precisa ter um nome válido.");

            RuleFor(m => m.Phone).Matches(@"^[1-9]{2}[1-9]{4,5}[0-9]{4}$")
                .WithMessage("O número de telefone deve ter exatamente 11 caracteres.");

            RuleFor(m => m.Role).IsInEnum()
                .WithMessage("Um membro precisa obrigatoriamente ter um cargo.");

        }
    }
}
