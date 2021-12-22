using System;

namespace Ekklesia.Entities.Entities
{
    public abstract class Occasion : BaseModel
    {
        public DateTime Date { get; set; }

        public Occasion()
        {
            this.Date = DateTime.Now;
        }
    }
}
