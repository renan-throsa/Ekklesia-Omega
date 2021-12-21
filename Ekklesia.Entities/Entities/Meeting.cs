using System.Collections.Generic;

namespace Ekklesia.Entities.Entities
{
    public class Meeting : Occasion
    {
        public ICollection<Member> Members { get; set; }
        public Member Speaker { get; set; }

        public Meeting()
        {
            this.Speaker = new Member();
            this.Members = new HashSet<Member>();
        }

        public void AddMember(Member member)
        {
            this.Members.Add(member);
        }
    }
}
