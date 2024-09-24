using System;

namespace Ekklesia.Domain.Filters
{
    public class OccasionFilterParams
    {
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
    }
}
