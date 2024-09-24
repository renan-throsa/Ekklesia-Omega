using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Enums;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Ekklesia.Domain.DTOs
{
    public class TransactionDTO : BaseDto<Transaction>
    {
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }

        [BsonIgnore]
        public string Receipt { get; set; }

        [BsonIgnore]
        public IFormFile? FormFile { get; set; }
        
        public MemberDTO Responsable { get; set; }

        public string TypeName
        {
            get { return Type.GetDescription() ; }
        }

        public TransactionType Type { get; set; }

        
        public override Transaction ToEntity(params string[] props)
        {
            
            return new Transaction()
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                Date = Date,
                Amount = Amount,
                Description = Description,
                Type = Type,
                Receipt = Receipt,
                Responsable = Responsable.ToEntity(nameof(MemberDTO.Name), nameof(MemberDTO.Id))
            };

        }

    }
}
