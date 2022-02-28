using System;

namespace Ekklesia.Entities.Entities
{
    public abstract class Occasion : BaseEntity
    {
        public DateTime Date { get; set; }

        public Occasion()
        {
            this.Date = DateTime.Now;
        }
    }
}
