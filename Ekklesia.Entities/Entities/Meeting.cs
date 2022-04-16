using System.Collections.Generic;

namespace Ekklesia.Entities.Entities
{
    public class Meeting : Occasion
    {
        public ISet<Member> Participants { get; set; }
        public Member Speaker { get; set; }

        public Meeting()
        {
            this.Speaker = new Member();
            this.Participants = new HashSet<Member>();
        }

        public void AddMember(Member member)
        {
            this.Participants.Add(member);
        }
    }
}
