namespace Ekklesia.Domain.Entities
{
    public class Member : BaseEntity
    {

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public Role Role { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Active { get; set; } = true;        

        public Member()
        {
            this.Name = string.Empty;
            this.Phone = string.Empty;
            this.Photo = string.Empty;
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
