using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class CultDTO : BaseDto<Cult>
    {
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
        public string KeyVerse { get; set; }
        public CultType? CultType { get; set; }
        public bool Internal { get; set; }
        public int Convertions { get; set; }

        public CultDTO()
        {
            this.CultType = null;
            this.KeyVerse = String.Empty;
        }
        public override Cult ToEntity(params string[] props)
        {
            return new Cult
            {
                Date = Date,
                NumberOfPeople = NumberOfPeople,
                CultType = CultType.HasValue ? CultType.Value : Enums.CultType.JOVENS,
                Internal = Internal,
                Convertions = Convertions
            };
        }
    }
}
