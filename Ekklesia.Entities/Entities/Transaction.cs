using Ekklesia.Entities.Enums;
using System;

namespace Ekklesia.Entities.Entities
{
    public class Transaction : BaseEntity
    {
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public string Receipt { get; set; }
        public Member Responsable { get; set; }
        public TransactionType Type { get; set; }

        public Transaction()
        {
            Description = string.Empty;
            this.Receipt = string.Empty;
            this.Responsable = new Member();
        }
    }
}
