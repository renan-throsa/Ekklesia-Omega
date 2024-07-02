using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Filters;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ekkleisa.Business.Implementation.Business
{
    public abstract class BusinessCrud<TEntity, TObject> : IBaseBusiness<TEntity, TObject> where TEntity : IEntity where TObject : IObject<TEntity>
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IValidator<TObject> _entityValidator;
        protected readonly IValidator<BaseFilter<TEntity, TObject>> _filterValidator;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;


        public BusinessCrud(IRepository<TEntity> repository, IMapper mapper, AbstractValidator<TObject> entityValidator, ILogger logger)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._entityValidator = entityValidator;
            this._filterValidator = new BaseFilterValidator<TEntity, TObject>();
            this._logger = logger;
        }

        public abstract IEnumerable<TObject> All();

        public virtual async Task<Response> AddAsync(TObject tObject)
        {
            _logger.LogInformation($"Adding object: {tObject.ToJson()}");
            ValidationResult result = _entityValidator.Validate(tObject, options => options.IncludeRuleSets(OperationType.Insert.ToString()));

            if (result.IsValid)
            {
                var entity = tObject.ToEntity();
                await _repository.AddAsync(entity);
                return Response(ResponseStatus.Created, _mapper.Map<TObject>(entity));
            }
            else
            {
                _logger.LogError(result.Errors.Select(x => x.ErrorMessage).ToJson());
                return Response(ResponseStatus.BadRequest, result.Errors.Select(x => x.ErrorMessage).ToList());
            }
        }

        public virtual async Task AddAsync(IEnumerable<TObject> dtos)
        {
            var entities = dtos.Select(x => x.ToEntity());
            await _repository.AddAsync(entities);
        }

        public virtual async Task<Response> FindSync(ObjectId key)
        {
            _logger.LogInformation($"Searching by key:{key}");
            var entity = await _repository.FindSync(key);
            if (entity == null)
            {
                var message = $"Key:{key} not found.";
                _logger.LogWarning(message);
                return Response(ResponseStatus.NotFound);
            }

            return Response(ResponseStatus.Found, _mapper.Map<TObject>(entity));
        }

        public virtual async Task<Response> FindSync(string id)
        {
            _logger.LogInformation($"Searching by key:{id}");
            if (ObjectId.TryParse(id, out var _))
            {
                var entity = await _repository.FindSync(id);
                if (entity == null)
                {
                    var message = $"Key:{id} was not found.";
                    _logger.LogWarning(message);
                    return Response(ResponseStatus.NotFound, message);
                }

                return Response(ResponseStatus.Found, _mapper.Map<TObject>(entity));
            }
            else
            {
                _logger.LogError($"Unable to parse the object: {id}");
                return null;
            }
        }

        public Task<IEnumerable<TObject>> FindAsync(Expression<Func<TObject, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(TObject tObject)
        {
            _logger.LogInformation($"Deleting by key:{tObject.Id}");
            var entity = tObject.ToEntity();
            return _repository.DeleteAsync(entity);
        }

        public virtual Task DeleteAsync(string id)
        {
            _logger.LogInformation($"Deleting by key:{id}");
            return _repository.DeleteAsync(id);
        }

        public virtual Task<DeleteResult> DeleteAsync(ObjectId id)
        {
            _logger.LogInformation($"Deleting by key:{id}");
            return _repository.DeleteAsync(id);
        }

        public virtual async Task<Response> UpdateAsync(TObject tObject)
        {
            _logger.LogInformation($"Updating object: {tObject.ToJson()}");

            ValidationResult result = _entityValidator.Validate(tObject, options => options.IncludeRuleSets(OperationType.Update.ToString()));
            if (result.IsValid)
            {
                var entity = await _repository.FindSync(tObject.Id);
                if (entity == null)
                {
                    var message = $"Key:{tObject.Id} not found.";
                    _logger.LogWarning(message);
                    return Response(ResponseStatus.NotFound);
                }
                entity = tObject.ToEntity();
                await _repository.UpdateAsync(entity);
                return Response(ResponseStatus.Ok, _mapper.Map<TObject>(entity));
            }
            else
            {
                _logger.LogError(result.Errors.Select(x => x.ErrorMessage).ToJson());
                return Response(ResponseStatus.BadRequest, result.Errors.Select(x => x.ErrorMessage).ToList());
            }

        }

        public virtual async Task<IEnumerable<TObject>> UpdateAsync(IEnumerable<TObject> tObjects)
        {
            var entities = tObjects.Select(x => x.ToEntity());
            entities = await _repository.UpdateAsync(entities);
            return _mapper.Map<IEnumerable<TObject>>(entities);
        }


        public virtual Response Browse(BaseFilter<TEntity, TObject> filter)
        {
            _logger.LogInformation($"Searching with filter:{filter}");

            Func<IEnumerable<TEntity>, IEnumerable<TObject>> mapTo = (entities) => _mapper.Map<IEnumerable<TObject>>(entities);

            ValidationResult result = _filterValidator.Validate(filter, options => options.IncludeRuleSets(OperationType.Default.ToString()));

            if (result.IsValid)
            {
                IMongoQueryable<TEntity> entities = _repository.GetQueryable();
                var filterResult = filter.OnQuery(entities).WithFiltering().WithSorting().WithPagination().Build(mapTo);
                return Response(ResponseStatus.Ok, filterResult);
            }
            else
            {
                _logger.LogError(result.Errors.Select(x => x.ErrorMessage).ToJson());
                return Response(ResponseStatus.BadRequest, result.Errors.Select(x => x.ErrorMessage).ToList());
            }

        }

        public BaseFilter<TEntity, TObject> GetFilter()
        {
            throw new NotImplementedException();
        }

        public void SaveFilter(BaseFilter<TEntity, TObject> filter)
        {
            throw new NotImplementedException();
        }

        protected Response Response(ResponseStatus valide, object result = null)
        {
            return
            new Response
            {
                Status = valide,
                Payload = result
            };
        }

    }
}
