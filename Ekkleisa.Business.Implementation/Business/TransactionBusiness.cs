using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Business.Implementation.Validations;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Microsoft.Extensions.Logging;
using System;

namespace Ekkleisa.Business.Implementation.Business
{
    public sealed class TransactionBusiness : BusinessCrud<Transaction, TransactionDTO>, ITransactionBusiness, IDisposable
    {
        public TransactionBusiness(ITransactionRepository transactionRepository, IMapper mapper, TransactionValidation validations, ILogger<TransactionBusiness> logger) : 
            base(transactionRepository, mapper, validations, logger)
        {
        }

        public void Dispose()
        {

        }
    }
}
