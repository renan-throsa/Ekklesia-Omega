using Ekklesia.Entities.DTOs;
using FluentValidation;

namespace Ekklesia.Entities.Validations
{
    public class CellReportValidation : AbstractValidator<CellReportDTO>
    {
        public CellReportValidation()
        {
            Include(new ReportValidation());

            RuleFor(cr => cr.NumberOfCoordinationMeetings).GreaterThanOrEqualTo(0).WithMessage("O número de encontros com a coordenação precisa ser maior ou igaul a zero.");
            RuleFor(cr => cr.NumberOfVisitants).GreaterThanOrEqualTo(0).WithMessage("O número de visitantes precisa ser maior ou igaul a zero.");
            RuleFor(cr => cr.NumberOfEvangelisms).GreaterThanOrEqualTo(0).WithMessage("O número de células de evangelismo precisa ser maior ou igaul a zero.");
            RuleFor(cr => cr.NumberOfBoardMembers).GreaterThanOrEqualTo(0).WithMessage("O número de membros do concelho precisa ser maior ou igaul a zero.");
        }
    }
}
