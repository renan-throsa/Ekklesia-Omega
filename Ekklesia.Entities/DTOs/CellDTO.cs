using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class CellDTO : BaseDto<Cell>
    {
        public int NumberOfConvertions { get; set; }
        public DateTime Date { get; set; }

        public CellDTO()
        {
            this.Id = string.Empty;
        }
        public override Cell ToEntity(params string[] props)
        {
            return new Cell()
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                NumberOfConvertions = NumberOfConvertions,
                Date = Date,
            };
        }
    }
}
