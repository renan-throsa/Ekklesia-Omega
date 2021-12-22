using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.Entities
{
    public class Baptism : Occasion
    {
        public string Place { get; set; }
        public int BaptizerId { get; set; }
        public Member Baptizer { get; set; }
        public ICollection<Member> Baptizeds { get; set; }

        public Baptism()
        {
            this.Place = string.Empty;
            this.Baptizer = new Member();
            this.Baptizeds = new HashSet<Member>();
        }
    }
}
