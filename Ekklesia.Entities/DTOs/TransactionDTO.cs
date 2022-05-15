using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using MongoDB.Bson;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class TransactionDTO : BaseDto<Transaction>
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public TransactionType Type { get; set; }

        public IncomeDTO? Income { get; set; }
        public ExpenseDTO? Expense { get; set; }

        public override Transaction ToEntity(params string[] props)
        {
            var transaction = new Transaction()
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                Date = Date,
                Value = Value,
                Type = Type,
            };
            if (this.Type == TransactionType.RECEITA)
            {
                transaction.Income = this.Income.ToEntity();
            }
            else
            {
                transaction.Expense = this.Expense.ToEntity();
            }

            return transaction;

        }
        
    }
}
