using AutoMapper;
using Ekkleisa.Business.Contract.IBusiness;
using Ekkleisa.Repository.Contract.IRepositories;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Validations;
using System;

namespace Ekkleisa.Business.Implementation.Business
{
    public sealed class TransactionBusiness : BusinessCrud<Transaction, TransactionDTO>, ITransactionBusiness, IDisposable
    {
        public TransactionBusiness(ITransactionRepository transactionRepository, IMapper mapper, TransactionValidation validations) : base(transactionRepository, mapper, validations)
        {
        }

        public void Dispose()
        {

        }
    }
}
