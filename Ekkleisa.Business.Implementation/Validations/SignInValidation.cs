using Ekklesia.Entities.DTOs;
using FluentValidation;

namespace Ekkleisa.Business.Implementation.Validations
{
    public class SignInValidation : AbstractValidator<SignInDTO>
    {
        public SignInValidation()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("Um endereço de email é necessário.")
                     .EmailAddress().WithMessage("Um email válido é necessário.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Uma senha é necessária.");

        }
    }
}
