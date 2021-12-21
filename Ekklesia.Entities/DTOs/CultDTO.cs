using Ekklesia.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.DTOs
{
    public class CultDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPeople { get; set; }
        public string KeyVerse { get; set; }
        public CultType? CultType { get; set; }
        public bool Internal { get; set; }
        public int Convertions { get; set; }

    }
}
