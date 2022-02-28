using System;

namespace Ekklesia.Entities.Entities
{
    public abstract class Transaction : BaseEntity
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }
    }
}
