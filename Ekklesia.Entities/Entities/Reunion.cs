using Ekklesia.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Ekklesia.Entities.Entities
{
    public class Reunion : Occasion
    {
        public string Topic { get; set; }
        public ReunionType ReunionType { get; set; }
        public DateTime EndTime { get; set; }
        public Member Speaker { get; set; }
        public int SpeakerId { get; set; }
        public ISet<OccasionMember> Members { get; set; }

        public Reunion()
        {
            this.Topic = string.Empty;
            this.Speaker = new Member();
            this.Members = new HashSet<OccasionMember>();
        }
    }
}
