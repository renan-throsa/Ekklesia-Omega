using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Ekklesia.Entities.DTOs
{
    public class BaptismDTO : BaseDto<Baptism>
    {

        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string BaptizerId { get; set; }
        public MemberDTO Baptizer { get; set; }
        public ICollection<MemberDTO> Baptizeds { get; set; }

        public BaptismDTO()
        {
            this.Place = string.Empty;
            this.BaptizerId = string.Empty;
            this.Baptizer = new MemberDTO();
            this.Baptizeds = new HashSet<MemberDTO>();
        }

        public override Baptism ToEntity(params string[] props)
        {
            return new Baptism()
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                Date = this.Date,
                Place = this.Place,
                BaptizerId= this.BaptizerId,
                Baptizer = this.Baptizer.ToEntity(nameof(MemberDTO.Name), nameof(MemberDTO.Id))
            };
        }
    }
}
