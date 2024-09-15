using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Filters;
using FluentValidation;

namespace Ekkleisa.Business.Validations
{
    public class BaseFilterValidator: AbstractValidator<BaseFilterParams>
    {
        public BaseFilterValidator()
        {
            RuleSet(OperationType.Default.ToString(), () =>
            {
                RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Invalid value for page number");
                RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("Invalid value for page size");
            });
        }
    }
}
