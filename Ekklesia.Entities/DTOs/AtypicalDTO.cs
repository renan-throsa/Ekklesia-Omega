using System;

namespace Ekklesia.Entities.DTOs
{
    public class AtypicalDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public AtypicalDTO()
        {
            this.Date = DateTime.Now;
            this.Description = string.Empty;
        }
    }
}
