using Ekklesia.Domain.Enums;
using Ekklesia.Domain.Filters;
using FluentValidation;

namespace Ekklesia.Application.Validations
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
