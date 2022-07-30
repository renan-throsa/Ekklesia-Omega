using Ekklesia.Entities.Contants;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Enums;
using FluentValidation;
using System;

namespace Ekkleisa.Business.Implementation.Validations
{
    public class OccasionValidation : AbstractValidator<OccasionDTO>
    {
        public OccasionValidation()
        {
            RuleSet(OperationType.Insert.ToString(), () =>
            {
                var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
                var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);

                RuleFor(m => m.Id).Empty();

                RuleFor(r => r.StartTime)
                    .ExclusiveBetween(LowerBound, UpperBound)
                    .WithMessage($"A data de uma ocasião prescisa estar entre {LowerBound:M} e {UpperBound:M}.");

                RuleFor(r => r.EndTime).NotEmpty()
                    .WithMessage("A data de fim de uma reunião não pode ser vazia.").When(x => x.Type == OccasionType.REUNIAOPEDAGOGICA || x.Type == OccasionType.REUNIAODOCENCIA || x.Type == OccasionType.REUNIAOLIDERANÇA)
                    .GreaterThan(x => x.StartTime).WithMessage("A data de fim de uma ocasião não pode ser menor que a data da reunião.")
                    .When(x => x.Type == OccasionType.REUNIAOPEDAGOGICA || x.Type == OccasionType.REUNIAODOCENCIA || x.Type == OccasionType.REUNIAOLIDERANÇA);

                RuleFor(r => r.Attendees).NotEmpty()
                    .When(x => 
                        x.Type == OccasionType.REUNIAOPEDAGOGICA || 
                        x.Type == OccasionType.REUNIAODOCENCIA || 
                        x.Type == OccasionType.REUNIAOLIDERANÇA ||
                        x.Type == OccasionType.BAPTISM ||
                        x.Type == OccasionType.SUNDAYSCHOOL)                    
                    .WithMessage("Uma ocasião precisa ter ao menos um participante.");

                RuleFor(r => r.Host).NotNull()
                    .When(x =>
                         x.Type == OccasionType.REUNIAOPEDAGOGICA ||
                         x.Type == OccasionType.REUNIAODOCENCIA ||
                         x.Type == OccasionType.REUNIAOLIDERANÇA ||
                         x.Type == OccasionType.BAPTISM ||
                         x.Type == OccasionType.SUNDAYSCHOOL)
                    .WithMessage("Uma ocasião precisa ter um responsável.");

                RuleFor(r => r.Host.Name)
                    .NotEmpty()
                    .When(r => r.Host != null)
                    .When(x => x.Type != OccasionType.CELL || x.Type != OccasionType.ATYPICAL)
                    .WithMessage("Uma ocasião precisa ter um dirigente válido.");

                RuleFor(r => r.Host.Id)
                    .NotEmpty()
                    .When(r => r.Host != null)
                    .When(x => x.Type != OccasionType.CELL || x.Type != OccasionType.ATYPICAL)
                    .WithMessage("Uma ocasião precisa ter um dirigente com Id válido.");

                RuleFor(r => r.Type)
                    .IsInEnum()
                    .WithMessage("Uma ocasião precisa obrigatoriamente ter um tipo.");

                RuleFor(r => r.Topic)
                    .NotEmpty()
                    .WithMessage("Uma reunião precisa ter obrigatoriamente um tópico.")
                    .When(r =>
                r.Type == OccasionType.REUNIAOPEDAGOGICA ||
                r.Type == OccasionType.REUNIAODOCENCIA ||
                r.Type == OccasionType.REUNIAOLIDERANÇA);

                RuleFor(b => b.Place).NotEmpty().WithMessage("O local de batismos não pode ser vazio.").When(r => r.Type == OccasionType.BAPTISM);

                RuleFor(a => a.Description)
                .MaximumLength(250).WithMessage("A descrição excede o limite.")
                .NotEmpty().WithMessage("Um evento atípico prescisa ter uma descrição.").When(r => r.Type == OccasionType.ATYPICAL);

                RuleFor(c => c.NumberOfConvertions)
                  .GreaterThanOrEqualTo(0)
                  .WithMessage("Número de conversões deve ser maior ou igual 0.");

            });

            RuleSet(OperationType.Update.ToString(), () =>
            {
                var UpperBound = DateTime.Now.AddDays(AplicationConstatants.UpperBoundDate);
                var LowerBound = DateTime.Now.AddDays(AplicationConstatants.LowerBoundDate);

                RuleFor(x => x.Id).NotEmpty();

                RuleFor(r => r.StartTime)
                    .ExclusiveBetween(LowerBound, UpperBound)
                    .WithMessage($"A data de uma ocasião prescisa estar entre {LowerBound.ToString("M")} e {UpperBound.ToString("M")}.");

                RuleFor(r => r.EndTime)
                    .NotEmpty()
                    .WithMessage("A data de fim de uma reunião não pode ser vazia.")
                    .When(r => r.Type == OccasionType.REUNIAOPEDAGOGICA || r.Type == OccasionType.REUNIAODOCENCIA || r.Type == OccasionType.REUNIAOLIDERANÇA)
                    .GreaterThan(r => r.StartTime).WithMessage("A data de fim de uma ocasião não pode ser menor que a data da reunião.")
                    .When(r => r.Type == OccasionType.REUNIAOPEDAGOGICA || r.Type == OccasionType.REUNIAODOCENCIA || r.Type == OccasionType.REUNIAOLIDERANÇA);

                RuleFor(r => r.Attendees).NotEmpty()
                     .When(x =>
                         x.Type == OccasionType.REUNIAOPEDAGOGICA ||
                         x.Type == OccasionType.REUNIAODOCENCIA ||
                         x.Type == OccasionType.REUNIAOLIDERANÇA ||
                         x.Type == OccasionType.BAPTISM ||
                         x.Type == OccasionType.SUNDAYSCHOOL)
                     .WithMessage("Uma ocasião precisa ter ao menos um participante.");


                RuleFor(r => r.Host).NotNull()
                .When(x =>
                         x.Type == OccasionType.REUNIAOPEDAGOGICA ||
                         x.Type == OccasionType.REUNIAODOCENCIA ||
                         x.Type == OccasionType.REUNIAOLIDERANÇA ||
                         x.Type == OccasionType.BAPTISM ||
                         x.Type == OccasionType.SUNDAYSCHOOL)
                .WithMessage("Uma ocasião precisa ter um responsável.");

                RuleFor(r => r.Host.Name).NotEmpty().When(r => r.Host != null).WithMessage("Uma ocasião precisa ter um dirigente válido.");

                RuleFor(r => r.Host.Id).NotEmpty().When(r => r.Host != null).WithMessage("Uma ocasião precisa ter um dirigente válido.");

                RuleFor(r => r.Type).IsInEnum()
                    .WithMessage("Uma ocasião precisa obrigatoriamente ter um tipo.");

                RuleFor(r => r.Topic).NotEmpty().WithMessage("Uma reunião precisa ter obrigatoriamente um tópico.").When(r =>
                r.Type == OccasionType.REUNIAOPEDAGOGICA ||
                r.Type == OccasionType.REUNIAODOCENCIA ||
                r.Type == OccasionType.REUNIAOLIDERANÇA);

                RuleFor(b => b.Place).NotEmpty().WithMessage("O local de batismos não pode ser vazio.").When(r => r.Type == OccasionType.BAPTISM);

                RuleFor(a => a.Description)
                            .MaximumLength(250).WithMessage("A descrição excede o limite.")
                            .NotEmpty().WithMessage("Um evento atípico prescisa ter uma descrição.").When(r => r.Type == OccasionType.ATYPICAL);

                RuleFor(c => c.NumberOfConvertions)
                  .GreaterThanOrEqualTo(0)
                  .WithMessage("Número de conversões deve ser maior ou igual 0.");
            });


        }
    }
}
