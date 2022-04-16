using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class ExpenseDTO : BaseDto<Expense>
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public string Receipt { get; set; }
        public string Description { get; set; }
        public MemberDTO Responsable { get; set; }

        public ExpenseDTO()
        {
            this.Date = DateTime.Now;
            this.Receipt = string.Empty;
            this.Description = string.Empty;
            this.Responsable = new MemberDTO();
        }
        public override Expense ToEntity(params string[] props)
        {
            return new Expense()
            {
                Id = string.IsNullOrEmpty(this.Id) ? ObjectId.Empty : ObjectId.Parse(this.Id),
                Date = this.Date,
                Value = this.Value,
                Receipt = this.Receipt,
                Description = this.Description,
                Responsable = this.Responsable.ToEntity(nameof(MemberDTO.Name), nameof(MemberDTO.Id))
            };
        }
    }
}
