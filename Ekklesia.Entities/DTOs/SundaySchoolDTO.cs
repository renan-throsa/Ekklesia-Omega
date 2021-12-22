using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.DTOs
{
    public class SundaySchoolDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public string Verse { get; set; }
        public int NumberOfBibles { get; set; }
        public int Visitants { get; set; }
        public MemberDTO Teacher { get; set; }
        public int TeacherId { get; set; }
        public ICollection<MemberDTO> Participants { get; set; }

        public SundaySchoolDTO()
        {
            this.Theme = string.Empty;
            this.Verse = string.Empty;
            this.Teacher = new MemberDTO();
            this.Participants = new HashSet<MemberDTO>();
        }

    }
}
