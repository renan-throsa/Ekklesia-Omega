using System.Collections.Generic;

namespace Ekklesia.Entities.Entities
{
    public class Baptism : Occasion
    {
        public string Place { get; set; }
        public string BaptizerId { get; set; }
        public Member Baptizer { get; set; }
        public ISet<OccasionMember> Baptizeds { get; set; }

        public Baptism()
        {
            this.Place = string.Empty;
            this.BaptizerId = string.Empty;
            this.Baptizer = new Member();
            this.Baptizeds = new HashSet<OccasionMember>();
        }
    }
}
