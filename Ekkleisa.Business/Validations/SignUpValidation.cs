using Ekklesia.Application.Models;
using FluentValidation;

namespace Ekklesia.Application.Validations
{
    public class SignUpValidation : AbstractValidator<SignUpModel>
    {
        public SignUpValidation()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é necessário.")
                   .MinimumLength(5).WithMessage("O comprimento do nome deve ser de pelo menos 5 caracteres.")
                   .MaximumLength(50).WithMessage("O comprimento do nome deve ser de no máximo 50 caracteres.")
                   .Matches(@"[A-Z]").WithMessage("O nome deve conter pelo menos uma letra maiúscula.")
                   .Matches(@"[a-z]").WithMessage("O nome deve conter pelo menos uma letra minúscula.")
                   .Matches(@"[^0-9]").WithMessage("O nome não deve conter múmeros.")
                   .Matches("[^{}@#$%¨&*£¢¬?!°<>.,:;/\'\"`+-]").WithMessage("O nome não deve conter caracteres especiais.");


            RuleFor(x => x.Phone).NotEmpty().WithMessage("Número de telefone é necessário.");

            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Endereço de email é necessário.")
                .EmailAddress().WithMessage("Um email válido é necessário.");


            RuleFor(x => x.Password).NotEmpty().WithMessage("A sua senha não pode ser vazia.")
                   .MinimumLength(8).WithMessage("O comprimento de sua senha deve ser de pelo menos 8 caracteres.")
                   .MaximumLength(16).WithMessage("O comprimento de sua senha não deve exceder 16. caracteres.")
                   .Matches(@"[A-Z]").WithMessage("Sua senha deve conter pelo menos uma letra maiúscula.")
                   .Matches(@"[a-z]").WithMessage("Sua senha deve conter pelo menos uma letra minúscula.")
                   .Matches(@"[^0-9]").WithMessage("Sua senha deve conter pelo menos um número.")
                   .Matches("[^{}@#$%¨&*£¢¬?!°<>.,:;/\'\"`+-]").WithMessage("Sua senha deve conter pelo menos um caractere especial.");


            RuleFor(x => x.ConfirmPassword).Equal(y => y.ConfirmPassword).WithMessage("As senhas não são iguais.");

        }
    }
}
