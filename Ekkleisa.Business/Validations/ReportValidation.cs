using Ekklesia.Domain.DTOs;
using FluentValidation;

namespace Ekklesia.Application.Validations
{
    public class ReportValidation : AbstractValidator<ReportDTO>
    {
        public ReportValidation()
        {

            RuleFor(r => r.Preacher).NotNull().WithMessage("Uma reunião precisa ter um pregador.");
            RuleFor(r => r.Preacher.Name).NotEmpty().When(r => r.Preacher != null).WithMessage("Uma reunião precisa ter um pregador válido.");
            RuleFor(r => r.Preacher.Id).NotEmpty().When(r => r.Preacher != null).WithMessage("Uma reunião precisa ter um pregador válido.");

            RuleFor(r => r.Coordinator).NotNull().WithMessage("Um relatório precisa ter um coordenador.");
            RuleFor(r => r.Coordinator.Name).NotEmpty().When(r => r.Preacher != null).WithMessage("Um relatório precisa ter um coordenador válido.");
            RuleFor(r => r.Coordinator.Id).NotEmpty().When(r => r.Preacher != null).WithMessage("Um relatório precisa ter um coordenador válido.");

            RuleFor(r => r.NumberOfReunions).GreaterThanOrEqualTo(0).WithMessage("O número de reuniões precisa ser maior ou igaul a zero.");
            RuleFor(r => r.NumberOfConvertions).GreaterThanOrEqualTo(0).WithMessage("O número de conversões precisa ser maior ou igaul a zero.");

            RuleFor(r => r.PreviousMonth).GreaterThanOrEqualTo(0).WithMessage("O valor do mês anterior precisa ser maior ou igaul a zero.");
            RuleFor(r => r.Income).GreaterThanOrEqualTo(0).WithMessage("O valor da receita precisa ser maior ou igaul a zero.");
            RuleFor(r => r.Expense).GreaterThanOrEqualTo(0).WithMessage("O valor da despesa precisa ser maior ou igaul a zero.");
            RuleFor(r => r.Tenth).GreaterThanOrEqualTo(0).WithMessage("O valor do dízimo precisa ser maior ou igaul a zero.");
        }
    }
}
