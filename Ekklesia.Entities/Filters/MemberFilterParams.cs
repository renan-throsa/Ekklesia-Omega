using Ekklesia.Entities.Entities;
using System;

namespace Ekklesia.Entities.Filters
{
    public class MemberFilterParams
    {
        public string Name { get; set; } = string.Empty;
        public Role? Role { get; set; }
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
    }
}
