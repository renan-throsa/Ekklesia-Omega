using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using MongoDB.Bson;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class TransactionDTO : BaseDto<Transaction>
    {
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public string Receipt { get; set; }
        public MemberDTO Responsable { get; set; }

        public string TypeName
        {
            get { return this.Type.GetDescription(); }

        }
        public TransactionType Type { get; set; }        

        public TransactionDTO()
        {
            Description = string.Empty;
            this.Receipt = string.Empty;
            this.Responsable = new MemberDTO();
        }

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
                Responsable = this.Responsable.ToEntity(nameof(MemberDTO.Name), nameof(MemberDTO.Id))
            };

        }

    }
}
