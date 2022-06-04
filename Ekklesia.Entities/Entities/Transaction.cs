using Ekklesia.Entities.Enums;
using System;

namespace Ekklesia.Entities.Entities
{
    public class Transaction : BaseEntity
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public TransactionType Type { get; set; }

        public Income? Income { get; set; }
        public Expense? Expense { get; set; }
    }
}
