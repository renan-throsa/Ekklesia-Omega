using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.Entities
{
    public class SundaySchool : Occasion
    {
        public string Theme { get; set; }
        public string Verse { get; set; }
        public int NumberOfBibles { get; set; }
        public int Visitants { get; set; }
        public Member Teacher { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Member> Participants { get; set; }

        public SundaySchool()
        {
            this.Theme = string.Empty;
            this.Verse = string.Empty;
            this.Teacher = new Member();
            this.Participants = new HashSet<Member>();
        }

    }
}
