using Ekklesia.Entities.Enums;
using System;

namespace Ekklesia.Entities.Filters
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
