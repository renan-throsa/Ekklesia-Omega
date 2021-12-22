using Ekklesia.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.Entities
{
    public class Reunion : Occasion
    {
        public string Topic { get; set; }
        public ReunionType ReunionType { get; set; }
        public DateTime EndTime { get; set; }
        public Member Speaker { get; set; }
        public int SpeakerId { get; set; }
        public ICollection<Member> Members { get; set; }

        public Reunion()
        {
            this.Topic = string.Empty;
            this.Speaker = new Member();
            this.Members = new HashSet<Member>();
        }
    }
}
