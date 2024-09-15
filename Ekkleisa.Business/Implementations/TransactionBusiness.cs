using AutoMapper;
using Ekkleisa.Business.Abstractions;
using Ekkleisa.Business.Implementation.Business;
using Ekkleisa.Business.Models;
using Ekkleisa.Business.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Filters;
using System.Net;

namespace Ekkleisa.Business.Implementations
{
    public sealed class TransactionBusiness : BaseBusiness, ITransactionBusiness
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionBusiness(ITransactionRepository transactionRepository, IMapper mapper) : base(mapper)
        {
            _transactionRepository = transactionRepository;
        }

        public OperationResultModel Browse(BaseFilterParams filterParams)
        {
            Func<IEnumerable<Transaction>, IEnumerable<ViewTransactionModel>> mapTo = (entities) => _mapper.Map<IEnumerable<ViewTransactionModel>>(entities);

            if (!ModelIsValid(new BaseFilterValidator(), filterParams))
                return Error();

            var filterResult = new TransactionFilter(_transactionRepository.GetQueryable(), filterParams)
                .WithFiltering()
                .WithSorting()
                .WithPagination()
                .WithFields(x => new Transaction() { Id = x.Id, Date = x.Date, Amount = x.Amount, Type = x.Type, Description = x.Description, Responsable = new Member { Id = x.Responsable.Id, Name = x.Responsable.Name } })
                .Build(mapTo);

            return Success(filterResult);
        }

        public OperationResultModel FindAll()
        {
            var entities = _transactionRepository.All(m => new Transaction() { Id = m.Id, Amount = m.Amount, Description = m.Description, Type = m.Type, Responsable = m.Responsable });
            return Success(_mapper.Map<IEnumerable<ViewTransactionModel>>(entities));
        }

        public async Task<OperationResultModel> FindById(string id)
        {
            var entity = await _transactionRepository.FindAsync(id);
            if (entity == null)
            {
                var message = $"Key:{id} not found.";
                return Error(message, HttpStatusCode.NotFound);
            }

            return Success(_mapper.Map<ViewTransactionModel>(entity));
        }

        public async Task<OperationResultModel> Insert(SaveTransactionModel model)
        {
            var entity = _mapper.Map<Transaction>(model);

            if (!EntityIsValid(new TransactionValidation(model.FormFile), entity, OperationType.Insert.ToString()))
                return Error();


            if (model.FormFile?.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.FormFile.CopyToAsync(memoryStream);
                    entity.Receipt = $"data:image/png;base64,{Convert.ToBase64String(memoryStream.ToArray())}";
                }

            }

            await _transactionRepository.AddAsync(entity);
            return Success(entity.Id);
        }

        public async Task<OperationResultModel> Update(EditTransactionModel model)
        {
            var entity = _mapper.Map<Transaction>(model);

            if (!EntityIsValid(new TransactionValidation(), entity, OperationType.Update.ToString()))
                return Error();

            var entityToUpdate = await _transactionRepository.FindAsync(model.Id);
            if (entity == null)
            {
                var message = $"Key:{model.Id} was not found.";
                return Error(message, HttpStatusCode.NotFound);
            }

            entityToUpdate.Description = model.Description;

            await _transactionRepository.UpdateAsync(entityToUpdate);
            return Success(entity.Id);
        }
    }
}
