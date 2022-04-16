using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekklesia.Entities.DTOs
{
    public class SundaySchoolDTO : BaseDto<SundaySchool>
    {
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public string Verse { get; set; }
        public int NumberOfBibles { get; set; }
        public int Visitants { get; set; }
        public MemberDTO Teacher { get; set; }
        public string TeacherId { get; set; }
        public ICollection<MemberDTO> Participants { get; set; }

        public SundaySchoolDTO()
        {
            this.Theme = string.Empty;
            this.Verse = string.Empty;
            this.TeacherId = string.Empty;
            this.Teacher = new MemberDTO();
            this.Participants = new HashSet<MemberDTO>();
        }

        public override SundaySchool ToEntity(params string[] props)
        {
            return new SundaySchool()
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                Date = this.Date,
                Theme = this.Theme,
                Verse = this.Verse,
                NumberOfBibles = this.NumberOfBibles,
                Visitants = this.Visitants,
                Teacher = this.Teacher.ToEntity(),
                TeacherId = this.TeacherId,
                Participants = this.Participants.Select(x => x.ToEntity(nameof(MemberDTO.Name), nameof(MemberDTO.Id))).ToHashSet()
            };
        }
    }
}
