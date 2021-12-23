using Ekklesia.Entities.Enums;
using System;

namespace Ekklesia.Entities.Filters
{
    public class TransactionFilter
    {
        public DateTime Before { get; set; }
        public DateTime After { get; set; }
        public float DiscountBiggerThan { get; set; }
        public float DiscountLessThan { get; set; }

    }
}
