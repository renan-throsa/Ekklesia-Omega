using Ekklesia.Entities.Enums;
using System;

namespace Ekklesia.Entities.Entities
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public Role Role { get; set; }
        public DateTime BirthDay { get; set; }

        public Member()
        {
            this.Name = string.Empty;
            this.Phone = string.Empty;
            this.Photo = string.Empty;
            this.Role = Role.INDEFINIDO;
        }
        public override bool Equals(object? obj)
        {
            Member? member = obj as Member;

            if (member == null)
            {
                return false;
            }
            return this.Id.Equals(member.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
