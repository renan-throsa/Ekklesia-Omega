using Ekklesia.Entities.DTOs;
using FluentValidation;

namespace Ekklesia.Entities.Validations
{
    public class SignUpValidation : AbstractValidator<SignUpDTO>
    {
        public SignUpValidation()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é necessário.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Número de telefone é necessário.");

            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Endereço de email é necessário.")
                .EmailAddress().WithMessage("Um email válido é necessário.");


            RuleFor(x => x.Password).NotEmpty().WithMessage("A sua senha não pode ser vazia.")
                   .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                   .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                   .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                   .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                   .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                   .Matches(@"[^\w\d]+").WithMessage("Your password must contain at least one special charcter.");


            RuleFor(x => x.ConfirmPassword).Equal(y => y.ConfirmPassword).WithMessage("As senhas não são iguais.");

        }
    }
}
