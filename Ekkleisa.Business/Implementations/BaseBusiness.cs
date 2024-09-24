using AutoMapper;
using Ekklesia.Application.Models;
using Ekklesia.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System.Net;

namespace Ekklesia.Application.Implementations
{
    public abstract class BaseBusiness
    {
        protected readonly IMapper _mapper;
        private ValidationResult _validationResult;

        protected BaseBusiness(IMapper mapper)
        {
            _mapper = mapper;
        }        

        protected OperationResultModel Error() => new OperationResultModel(_validationResult);

        protected OperationResultModel Error(HttpStatusCode statusCode) => new OperationResultModel(_validationResult, statusCode);

        protected OperationResultModel Error(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure(string.Empty, errorMessage) };
            return new OperationResultModel(new ValidationResult(failures), statusCode);
        }

        protected OperationResultModel Success(object obj = null) => new OperationResultModel(obj);

        protected OperationResultModel Success(long id) => new OperationResultModel(id);


        protected bool EntityIsValid<TV, TE>(TV validator, TE entity, params string[] ruleSets) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            ValidationResult result;
            if (ruleSets == null)
            {
                result = validator.Validate(entity);
            }
            else
            {
                result = validator.Validate(entity, options => options.IncludeRuleSets(ruleSets));
            }

            if (result.IsValid) return true;

            _validationResult = result;
            return false;
        }

        protected bool EntityIsValid<TV, TE>(TV validator, TE entity) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            ValidationResult result;
            result = validator.Validate(entity);
            if (result.IsValid) return true;
            _validationResult = result;
            return false;
        }

        protected bool ModelIsValid<TV, TE>(TV validator, TE model) where TV : AbstractValidator<TE>
        {
            ValidationResult result;
            result = validator.Validate(model);
            if (result.IsValid) return true;
            _validationResult = result;
            return false;
        }


        protected bool EntityIsValid<TV, TE>(TV validator, IEnumerable<TE> entities) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            foreach (var item in entities)
            {
                var result = validator.Validate(item);
                if (!result.IsValid)
                {
                    _validationResult = result;
                    return false;
                }
            }

            return true;
        }

    }
}
