using Ekklesia.Entities.Entities;
using System;
using System.Collections.Generic;

namespace Ekklesia.Entities.DTOs
{
    public class MeetingDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public MemberDTO Speaker { get; set; }
        public ICollection<MemberDTO> Participants { get; set; }

        public MeetingDTO()
        {
            this.Speaker = new MemberDTO();
            this.Participants = new HashSet<MemberDTO>();
        }
    }
}
