using Ekklesia.Entities.Enums;
using FluentValidation;
using FluentValidation.Results;

namespace Ekklesia.Tests.Base
{
    public abstract class BaseTest<D, V> where D : new() where V : AbstractValidator<D>, new()
    {
        protected D DTO { get; }

        private V Validation { get; }

        public BaseTest()
        {
            DTO = new D();
            Validation = new V();
        }

        protected ValidationResult IsValid(string prop)
        {
            return Validation.Validate(DTO, options =>
            {
                options.IncludeProperties(prop);
            });
        }

        protected ValidationResult IsValid(params string[] props)
        {
            return Validation.Validate(DTO, options =>
            {
                foreach (var prop in props)
                {
                    options.IncludeProperties(prop);
                }
            });
        }

        protected ValidationResult IsValid(D DTO)
        {
            return Validation.Validate(DTO, options => options.IncludeRuleSets(OperationType.Insert.ToString()));
        }
    }
}
