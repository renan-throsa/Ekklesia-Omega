using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Filters;
using FluentValidation;

namespace Ekkleisa.Business.Implementation.Validations
{
    public class BaseFilterValidator<TEntity, TObject> : AbstractValidator<BaseFilter<TEntity, TObject>> where TEntity : IEntity where TObject : IObject<TEntity>
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
