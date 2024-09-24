using Ekklesia.Domain.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Application.Validations
{
    public class BiblicalReportValidation : AbstractValidator<BiblicalReportDTO>
    {
        public BiblicalReportValidation()
        {
            Include(new ReportValidation());

            RuleFor(br => br.NumberOfBibles).GreaterThanOrEqualTo(0).WithMessage("O número de bíblias externos precisa ser maior ou igaul a zero.");
            RuleFor(br => br.NumberOfReunionWithTeachers).GreaterThanOrEqualTo(0).WithMessage("O número de reuniões com os professores precisa ser maior ou igaul a zero.");
            RuleFor(br => br.NumberOfVisitants).GreaterThanOrEqualTo(0).WithMessage("O número de visitantes precisa ser maior ou igaul a zero.");
            RuleFor(br => br.NumberOfPeopleAttending).GreaterThanOrEqualTo(0).WithMessage("O número de presentes precisa ser maior ou igaul a zero.");
            RuleFor(br => br.NumberOfPeopleInPedagogicalBody).GreaterThanOrEqualTo(0).WithMessage("O número de pessoas no corpo pedagógico precisa ser maior ou igaul a zero.");

        }
    }
}
