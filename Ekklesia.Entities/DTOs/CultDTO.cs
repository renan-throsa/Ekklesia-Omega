using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class CultDTO
    {
        public int NumberOfPeople { get; set; }
        public string KeyVerse { get; set; }
        public CultType CultType { get; set; }
        public bool Internal { get; set; }

        public CultDTO()
        {
            this.KeyVerse = string.Empty;
        }

        public Cult ToEntity()
        {
            return new Cult
            {
                NumberOfPeople = NumberOfPeople,
                CultType = CultType,
                Internal = Internal,
            };
        }
    }
}
