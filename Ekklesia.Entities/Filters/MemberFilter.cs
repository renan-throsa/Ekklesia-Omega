using Ekklesia.Entities.Entities;

namespace Ekklesia.Entities.Filters
{
    public class MemberFilter
    {
        public string Name { get; set; } = string.Empty;
        public Role? Role { get; set; }
    }
}
