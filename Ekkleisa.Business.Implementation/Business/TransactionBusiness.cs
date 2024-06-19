using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ekkleisa.Business.Implementation.Business
{
    public sealed class TransactionBusiness : BusinessCrud<Transaction, TransactionDTO>, ITransactionBusiness, IDisposable
    {
        public TransactionBusiness(ITransactionRepository transactionRepository, IMapper mapper, TransactionValidation transactionValidation, ILogger<TransactionBusiness> logger) :
            base(transactionRepository, mapper, transactionValidation, logger)
        {
        }

        public override IEnumerable<TransactionDTO> All()
        {
            throw new NotImplementedException();
        }

        public async override Task<Response> AddAsync(TransactionDTO tObject)
        {
            _logger.LogInformation($"Adding {nameof(Transaction)}: {tObject.ToJson()}");
            ValidationResult result = _entityValidator.Validate(tObject, options => options.IncludeRuleSets(OperationType.Insert.ToString()));

            if (!result.IsValid)
            {
                _logger.LogError(result.Errors.Select(x => x.ErrorMessage).ToJson());
                return Response(ResponseStatus.BadRequest, result.Errors.Select(x => x.ErrorMessage).ToList());

            }

            if (tObject.FormFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await tObject.FormFile.CopyToAsync(memoryStream);
                    tObject.Receipt = Convert.ToBase64String(memoryStream.ToArray());
                }

            }

            var entity = tObject.ToEntity();
            await _repository.AddAsync(entity);
            return Response(ResponseStatus.Created);
        }

        public async override Task<Response> UpdateAsync(TransactionDTO tObject)
        {
            _logger.LogInformation($"Updating {nameof(Transaction)}: {tObject.ToJson()}");
            ValidationResult result = _entityValidator.Validate(tObject, options => options.IncludeRuleSets(OperationType.Update.ToString()));

            var entity = await _repository.FindSync(tObject.Id);
            if (entity == null)
            {
                var message = $"Key:{tObject.Id} was not found.";
                _logger.LogWarning(message);
                return Response(ResponseStatus.NotFound, message);
            }

            if (!result.IsValid)
            {
                _logger.LogError(result.Errors.Select(x => x.ErrorMessage).ToJson());
                return Response(ResponseStatus.BadRequest, result.Errors.Select(x => x.ErrorMessage).ToList());
            }

            if (tObject.FormFile?.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await tObject.FormFile.CopyToAsync(memoryStream);

                    entity.Receipt = $"data:image/png;base64,{Convert.ToBase64String(memoryStream.ToArray())}";
                }

            }

            entity.Description = tObject.Description;

            await _repository.UpdateAsync(entity);
            return Response(ResponseStatus.Ok);
        }

        public void Dispose()
        {

        }
    }
}
