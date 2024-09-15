using Ekklesia.Entities.Entities;

namespace Ekkleisa.Business.Models
{
    public class ViewMemberModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public Role Role { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
