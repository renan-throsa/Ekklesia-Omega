using Ekklesia.Domain.Enums;
using System;

namespace Ekklesia.Domain.Filters
{
    public class TransactionFilterParams
    {
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
        public TransactionType Type { get; set; }
        public float BiggerThan { get; set; }
        public float LessThan { get; set; }

    }
}
