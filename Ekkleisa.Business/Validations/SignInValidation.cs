using Ekkleisa.Business.Models;
using FluentValidation;

namespace Ekkleisa.Business.Validations
{
    public class SignInValidation : AbstractValidator<SignInModel>
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
