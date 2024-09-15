﻿using Ekklesia.Entities.Enums;

namespace Ekkleisa.Business.Models
{
    public class ViewCultModel
    {
        public int NumberOfPeople { get; set; }
        public string KeyVerse { get; set; }
        public CultType CultType { get; set; }
        public bool Internal { get; set; }
    }
}
