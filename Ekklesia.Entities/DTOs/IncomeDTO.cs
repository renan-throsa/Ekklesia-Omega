using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using MongoDB.Bson;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class IncomeDTO : BaseDto<Income>
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public RevenueType? Type { get; set; }

        public override Income ToEntity(params string[] props)
        {
            return new Income()
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                Date = Date,
                Value = Value,
                Type = Type.HasValue ? Type.Value : RevenueType.OFERTA,
            };
        }
    }
}
