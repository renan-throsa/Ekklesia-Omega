using Ekklesia.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.DTOs
{
    public class ReunionDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public ReunionType? ReunionType { get; set; }
        public DateTime EndTime { get; set; }
        public MemberDTO Speaker { get; set; }
        public int SpeakerId { get; set; }
        public ICollection<MemberDTO> Participants { get; set; }

        public ReunionDTO()
        {
            this.Topic = string.Empty;
            this.Speaker = new MemberDTO();
            this.Participants = new HashSet<MemberDTO>();
        }
    }
}
