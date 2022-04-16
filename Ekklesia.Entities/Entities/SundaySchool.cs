using System.Collections.Generic;

namespace Ekklesia.Entities.Entities
{
    public class SundaySchool : Occasion
    {
        public string Theme { get; set; }
        public string Verse { get; set; }
        public int NumberOfBibles { get; set; }
        public int Visitants { get; set; }
        public Member Teacher { get; set; }
        public string TeacherId { get; set; }
        public ISet<Member> Participants { get; set; }

        public SundaySchool()
        {
            this.Theme = string.Empty;
            this.Verse = string.Empty;
            this.TeacherId = string.Empty;
            this.Teacher = new Member();            
            this.Participants = new HashSet<Member>();
        }

    }
}
