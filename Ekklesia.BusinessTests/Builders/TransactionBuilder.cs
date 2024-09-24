using Ekklesia.Domain.DTOs;
using Ekklesia.Domain.Enums;
using System;


namespace Ekklesia.IntegrationTesting.Builders
{
    internal class TransactionBuilder
    {
        private DateTime Date { get; set; }
        private float Value { get; set; }
        private TransactionType? Type { get; set; }
        private IncomeDTO? Income { get; set; }
        private ExpenseDTO? Expense { get; set; }

        public TransactionBuilder()
        {
             
        }
    }
}
