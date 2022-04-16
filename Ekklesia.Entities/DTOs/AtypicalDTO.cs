using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class AtypicalDTO : BaseDto<Atypical>
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public AtypicalDTO()
        {
            this.Date = DateTime.Now;
            this.Description = string.Empty;
        }

        public override Atypical ToEntity(params string[] props)
        {
            return new Atypical()
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                Date = this.Date,
                Description = this.Description,
            };
        }
    }
}
