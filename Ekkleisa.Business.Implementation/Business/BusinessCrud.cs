using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
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
    public abstract class BusinessCrud<TEntity, TObject> : IBaseBusiness<TEntity, TObject> where TEntity : class, IEntity where TObject : BaseDto<TEntity>
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IValidator<TObject> _validator;
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;


        public BusinessCrud(IRepository<TEntity> repository, IMapper mapper, AbstractValidator<TObject> validator, ILogger logger)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._validator = validator;
            this._logger = logger;
        }

        public Task AddAsync(TObject tObject)
        {
            _logger.LogInformation($"Adding object: {tObject.ToJson()}");
            Task task;
            ValidationResult result = _validator.Validate(tObject, options => options.IncludeRuleSets(OperationType.Insert.ToString()));
            if (result.IsValid)
            {
                var entity = tObject.ToEntity();
                task = _repository.AddAsync(entity);
                tObject.Id = entity.Id.ToString();
            }
            else
            {
                _logger.LogError(result.ToJson());
                task = Task.CompletedTask;
            }
            return task;
        }

        public async Task AddAsync(IEnumerable<TObject> dtos)
        {
            var entities = dtos.Select(x => x.ToEntity());
            await _repository.AddAsync(entities);
        }

        public async Task<TObject> FindSync(ObjectId key)
        {
            _logger.LogInformation($"Searching by key:{key}");
            var entity = await _repository.FindSync(key);
            if (entity == null) _logger.LogWarning($"Key:{key} not found.");
            return _mapper.Map<TObject>(entity);
        }

        public async Task<TObject> FindSync(string id)
        {
            _logger.LogInformation($"Searching by key:{id}");
            if (ObjectId.TryParse(id, out var _))
            {
                var entity = await _repository.FindSync(id);
                if (entity == null) _logger.LogWarning($"Key:{id} not found.");
                return _mapper.Map<TObject>(entity);
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

        public async Task<IEnumerable<TObject>> AllAsync()
        {
            var entities = await _repository.AllAsync();
            return entities.Select(x => _mapper.Map<TObject>(x));
        }

        public Task DeleteAsync(TObject tObject)
        {
            _logger.LogInformation($"Deleting by key:{tObject.Id}");
            var entity = _mapper.Map<TEntity>(tObject);
            return _repository.DeleteAsync(entity);
        }

        public Task DeleteAsync(string id)
        {
            _logger.LogInformation($"Deleting by key:{id}");
            return _repository.DeleteAsync(id);
        }

        public Task<DeleteResult> DeleteAsync(ObjectId id)
        {
            _logger.LogInformation($"Deleting by key:{id}");
            return _repository.DeleteAsync(id);
        }

        public Task UpdateAsync(TObject tObject)
        {
            _logger.LogInformation($"Updating object: {tObject.ToJson()}");
            Task task;
            ValidationResult result = _validator.Validate(tObject, options => options.IncludeRuleSets(OperationType.Update.ToString()));
            if (result.IsValid)
            {
                var entity = _mapper.Map<TEntity>(tObject);
                task = _repository.UpdateAsync(entity);
                tObject.Id = entity.Id.ToString();
            }
            else
            {
                _logger.LogError(result.ToJson());
                task = Task.CompletedTask;
            }
            return task;
        }

        public async Task<IEnumerable<TObject>> UpdateAsync(IEnumerable<TObject> tObjects)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(tObjects);
            entities = await _repository.UpdateAsync(entities);
            return _mapper.Map<IEnumerable<TObject>>(entities);
        }


    }
}
