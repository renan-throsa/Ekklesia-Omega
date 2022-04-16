using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekklesia.Entities.DTOs
{
    public class MeetingDTO : BaseDto<Meeting>
    {       
        public DateTime Date { get; set; }
        public MemberDTO Speaker { get; set; }
        public ICollection<MemberDTO> Participants { get; set; }

        public MeetingDTO()
        {
            this.Speaker = new MemberDTO();
            this.Participants = new HashSet<MemberDTO>();
        }

        public override Meeting ToEntity(params string[] props)
        {
            return new Meeting()
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                Date = this.Date,
                Speaker = this.Speaker.ToEntity(),
                Participants = this.Participants.Select(x => x.ToEntity(nameof(MemberDTO.Name), nameof(MemberDTO.Id))).ToHashSet()
            };
        }
    }
}
