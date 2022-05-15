using Ekklesia.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Ekklesia.Entities.Entities
{
    public class Occasion : BaseEntity
    {
        public OccasionType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Member Host { get; set; }
        public ISet<Member> Attendees { get; set; }
        public string Place { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; } = string.Empty;
        public int NumberOfConvertions { get; set; }
        public int NumberOfVisitants { get; set; }
        public Cult? Cult { get; set; }
        public SundaySchool? SundaySchool { get; set; }

        public Occasion()
        {
            this.Place = string.Empty;
            this.Topic = string.Empty;
            this.Host = new Member();
            this.Attendees = new HashSet<Member>();
        }
                
    }
}
