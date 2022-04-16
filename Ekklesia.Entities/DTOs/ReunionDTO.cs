using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekklesia.Entities.DTOs
{
    public class ReunionDTO : BaseDto<Reunion>
    {
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public ReunionType? ReunionType { get; set; }
        public DateTime EndTime { get; set; }
        public MemberDTO Speaker { get; set; }
        public string SpeakerId { get; set; }
        public ICollection<MemberDTO> Participants { get; set; }

        public ReunionDTO()
        {
            this.Date = DateTime.Now;
            this.Topic = string.Empty;
            this.Speaker = new MemberDTO();
            this.SpeakerId = string.Empty;
            this.Participants = new HashSet<MemberDTO>();
        }

        public override Reunion ToEntity(params string[] props)
        {
            return new Reunion()
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                Date = this.Date,
                EndTime = this.EndTime,
                Topic = this.Topic,
                Speaker = this.Speaker.ToEntity(),
                SpeakerId = this.SpeakerId,
                ReunionType = this.ReunionType.HasValue ? this.ReunionType.Value : Enums.ReunionType.LIDERANÇA,
                Participants = this.Participants.Select(x => x.ToEntity(nameof(MemberDTO.Name), nameof(MemberDTO.Id))).ToHashSet()
            };
        }
    }
}
