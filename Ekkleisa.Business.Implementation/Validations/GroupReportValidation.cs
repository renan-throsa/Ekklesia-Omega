using Ekklesia.Entities.DTOs;
using FluentValidation;

namespace Ekkleisa.Business.Implementation.Validations
{
    public class GroupReportValidation : AbstractValidator<GroupReportDTO>
    {
        public GroupReportValidation()
        {
            Include(new ReportValidation());

            RuleFor(gr => gr.NumberOfExternalCults).GreaterThanOrEqualTo(0).WithMessage("O número de cultos externos precisa ser maior ou igaul a zero.");
            RuleFor(gr => gr.NumberOfCells).GreaterThanOrEqualTo(0).WithMessage("O número de células precisa ser maior ou igaul a zero.");
            RuleFor(gr => gr.NumberOfBaptizeds).GreaterThanOrEqualTo(0).WithMessage("O número de batizados precisa ser maior ou igaul a zero.");
            RuleFor(gr => gr.NumberOfCoordinationMeetings).GreaterThanOrEqualTo(0).WithMessage("O número de encontros com a coordenação precisa ser maior ou igaul a zero.");
        }
    }
}
