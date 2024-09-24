using System;

namespace Ekklesia.Domain.Filters
{
    public class ReportFilterParams
    {
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }

        public float BalanceBiggerThan { get; set; }
        public float BalanceLessThan { get; set; }

        public float IncomeBiggerThan { get; set; }
        public float IncomeLessThan { get; set; }

        public float ExpenseBiggerThan { get; set; }
        public float ExpenseLessThan { get; set; }
    }
}
