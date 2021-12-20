using Ekklesia.Entities.Entities;

namespace Ekklesia.Entities.DTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public Role? Role { get; set; }

    }
}
