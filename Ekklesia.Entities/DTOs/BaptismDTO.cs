using System;
using System.Collections.Generic;

namespace Ekklesia.Entities.DTOs
{
    public class BaptismDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public int BaptizerId { get; set; }
        public MemberDTO Baptizer { get; set; }
        public ICollection<MemberDTO> Baptizeds { get; set; }

        public BaptismDTO()
        {
            this.Place = string.Empty;
            this.Baptizer = new MemberDTO();
            this.Baptizeds = new HashSet<MemberDTO>();
        }
    }
}
