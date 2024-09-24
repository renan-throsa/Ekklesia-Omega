using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekklesia.Domain.DTOs
{
    public class OccasionDTO : BaseDto<Occasion>
    {
        public OccasionType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public MemberDTO? Host { get; set; }
        public ISet<MemberDTO>? Attendees { get; set; }
        public string Place { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; } = string.Empty;
        public int NumberOfConvertions { get; set; }
        public int NumberOfVisitants { get; set; }
        public CultDTO? Cult { get; set; }
        public SundaySchoolDTO? SundaySchool { get; set; }


        public OccasionDTO()
        {
            this.Place = string.Empty;
            this.Topic = string.Empty;
            this.Host = new MemberDTO();
            this.Attendees = new HashSet<MemberDTO>();
        }


        public override Occasion ToEntity(params string[] props)
        {
            return new Occasion
            {
                Type = this.Type,
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                Host = this.Host?.ToEntity(),
                Attendees = this.Attendees?.Select(x => x.ToEntity()).ToHashSet(),
                Place = this.Place,
                Topic = this.Topic,
                Description = this.Description,
                NumberOfConvertions = this.NumberOfConvertions,
                NumberOfVisitants = this.NumberOfVisitants,
                Cult = this.Cult?.ToEntity(),
                SundaySchool = this.SundaySchool?.ToEntity(),
            };
        }
    }
}
