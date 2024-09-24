using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Ekklesia.Application.Validations
{
    public class MemberValidation : AbstractValidator<Member>
    {
        const int muiltiplier = 2;
        const int oneMegaByte = 1048576;
        const int allowedSize = muiltiplier * oneMegaByte;

        public MemberValidation(IFormFile? file)
        {
            RuleSet(OperationType.Insert.ToString(), () =>
            {
                RuleFor(m => m.Id).Empty().WithMessage("Um membro não pode ter um Id para inserção.");

                RuleFor(m => m.Name).Matches(@"^[A-ZÀ-Ÿ][A-zÀ-ÿ']+\s([A-zÀ-ÿ']\s?)*[A-ZÀ-Ÿ][A-zÀ-ÿ']+$")
                .WithMessage("Um membro precisa ter um nome válido.");

                RuleFor(m => m.Phone).NotEmpty().Matches(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$").WithMessage("Telefone não está no formato correto."); 

                RuleFor(m => m.Role).NotNull().WithMessage("Um membro precisa ter um cargo.");

                RuleFor(m => m.Role).IsInEnum()
                    .WithMessage("Um membro precisa ter um cargo válido.");

                RuleFor(m => file.Length)
                    .LessThanOrEqualTo(allowedSize)
                    .WithMessage($"O tamanho máximo do arquivo permitido é de {muiltiplier}MB")
                    .When(m=> file != null);


                RuleFor(m => file.ContentType).Must(m => m == "image/jpeg").When(m => file != null).WithMessage("Somente imagens .jpg são aceitas.");                    
                   

                RuleFor(m => m.BirthDay).InclusiveBetween(DateTime.Today.AddYears(-100), DateTime.Today).WithMessage($"Data de aniversario deve estar entre {DateTime.Today.AddYears(-100)} e {DateTime.Today}");

            });

            RuleSet(OperationType.Update.ToString(), () =>
            {
                RuleFor(m => m.Id).NotEmpty().WithMessage("Um membro precisa ter um Id para atualização.");

                RuleFor(m => m.Name).Matches(@"^[A-ZÀ-Ÿ][A-zÀ-ÿ']+\s([A-zÀ-ÿ']\s?)*[A-ZÀ-Ÿ][A-zÀ-ÿ']+$")
                .WithMessage("Um membro precisa ter um nome válido.");

                RuleFor(m => m.Phone).NotEmpty().Matches(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$").WithMessage("Telefone não está no formato correto."); 

                RuleFor(m => m.Role).NotNull().WithMessage("Um membro precisa ter um cargo.");

                RuleFor(m => m.Role).IsInEnum()
                    .WithMessage("Um membro precisa obrigatoriamente ter um cargo.");


                RuleFor(m => file.Length)
                    .LessThanOrEqualTo(allowedSize)
                    .WithMessage($"O tamanho máximo do arquivo permitido é de {muiltiplier}MB")
                    .When(m => file != null);


                RuleFor(m => file.ContentType).Must(m => m == "image/jpeg").When(m => file != null).WithMessage("Somente imagens .jpg são aceitas.");


                RuleFor(m => m.BirthDay).InclusiveBetween(DateTime.Today.AddYears(-100), DateTime.Today).WithMessage($"Data de aniversario deve estar entre {DateTime.Today.AddYears(-100)} e {DateTime.Today}");

            });

            RuleSet(OperationType.Delete.ToString(), () =>
            {
                RuleFor(m => m.Id).NotEmpty().WithMessage("Um membro precisa ter um Id para deleção.");
            });

        }
    }
}
