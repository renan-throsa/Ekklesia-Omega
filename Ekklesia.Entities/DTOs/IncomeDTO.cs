using Ekklesia.Entities.Enums;
using System;

namespace Ekklesia.Entities.DTOs
{
    public class IncomeDTO
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public RevenueType? Type { get; set; }
    }
}
