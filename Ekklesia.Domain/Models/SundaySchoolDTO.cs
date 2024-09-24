using Ekklesia.Domain.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ekklesia.Domain.DTOs
{
    public class SundaySchoolDTO
    {
        public string Theme { get; set; }
        public string Verse { get; set; }
        public int NumberOfBibles { get; set; }
        public int Visitants { get; set; }

        public SundaySchoolDTO()
        {
            this.Theme = string.Empty;
            this.Verse = string.Empty;
        }

        public SundaySchool ToEntity()
        {
            return new SundaySchool()
            {
                Theme = this.Theme,
                Verse = this.Verse,
                NumberOfBibles = this.NumberOfBibles,
                Visitants = this.Visitants,
            };
        }
    }
}
