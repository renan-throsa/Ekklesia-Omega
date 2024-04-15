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
        public TransactionBusiness(ITransactionRepository transactionRepository, IMapper mapper, TransactionValidation transactionValidation, ILogger<TransactionBusiness> logger) :
            base(transactionRepository, mapper, transactionValidation, logger)
        {
        }

        public void Dispose()
        {

        }
    }
}
