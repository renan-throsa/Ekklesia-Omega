using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using FluentValidation;
using System;

namespace Ekkleisa.Business.Implementation.Validations
{
    public class MemberValidation : AbstractValidator<MemberDTO>
    {
        const int muiltiplier = 2;
        const int oneMegaByte = 1048576;
        const int allowedSize = muiltiplier * oneMegaByte;

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

                RuleFor(m => m.FormFile.Length)
                    .LessThanOrEqualTo(allowedSize)
                    .WithMessage($"O tamanho máximo do arquivo permitido é de {muiltiplier}MB")
                    .When(m=> m.FormFile != null);


                RuleFor(m => m.FormFile.ContentType).Must(m => m == "image/jpeg").When(m => m.FormFile != null).WithMessage("Somente imagens .jpg são aceitas");                    
                   

                RuleFor(m => m.BirthDay).LessThanOrEqualTo(DateTime.Now).WithMessage("Data de aniversario não pode ser no futuro.");

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


                RuleFor(m => m.FormFile.Length)
                    .LessThanOrEqualTo(allowedSize)
                    .WithMessage($"O tamanho máximo do arquivo permitido é de {muiltiplier}MB")
                    .When(m => m.FormFile != null);


                RuleFor(m => m.FormFile.ContentType).Must(m => m == "image/jpeg").When(m => m.FormFile != null).WithMessage("Somente imagens .jpg são aceitas");


                RuleFor(m => m.BirthDay).LessThanOrEqualTo(DateTime.Now).WithMessage("Data de aniversario não pode ser no futuro.");

            });

            RuleSet(OperationType.Delete.ToString(), () =>
            {
                RuleFor(m => m.Id).NotEmpty();
            });

        }
    }
}
