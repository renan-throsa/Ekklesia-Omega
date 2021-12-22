using Ekklesia.Entities.Enums;
using System;

namespace Ekklesia.Entities.Entities
{
    public class Income : Transaction
    {
        public RevenueType Type { get; set; }

        public Income()
        {
            this.Date = DateTime.Now;
        }


    }
}
