using System;

namespace Ekklesia.Entities.DTOs
{
    public class ExpenseDTO
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public string Receipt { get; set; }
        public string Description { get; set; }
    }
}
