using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using FluentValidation;
using FluentValidation.Results;
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

        public BusinessCrud(IRepository<TEntity> repository, IMapper mapper, AbstractValidator<TObject> validator)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._validator = validator;
        }

        public Task AddAsync(TObject dto)
        {
            Task task;
            ValidationResult result = _validator.Validate(dto, options => options.IncludeRuleSets(OperationType.Insert.ToString()));
            if (result.IsValid)
            {
                var entity = dto.ToEntity();
                task = _repository.AddAsync(entity);
                dto.Id = entity.Id.ToString();                
            }
            else
            {
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
            var entity = await _repository.FindSync(key);
            return _mapper.Map<TObject>(entity);
        }

        public async Task<TObject> FindSync(string id)
        {
            var entity = await _repository.FindSync(id);
            return _mapper.Map<TObject>(entity);
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
            var entity = _mapper.Map<TEntity>(tObject);
            return _repository.DeleteAsync(entity);
        }

        public Task DeleteAsync(string id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<DeleteResult> DeleteAsync(ObjectId id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task UpdateAsync(TObject tObject)
        {
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
