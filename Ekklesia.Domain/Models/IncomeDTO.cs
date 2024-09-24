using Ekklesia.Domain.Entities;
using Ekklesia.Domain.Enums;

namespace Ekklesia.Domain.DTOs
{
    public class IncomeDTO
    {
        public RevenueType Type { get; set; }
        public string Observation { get; set; }

        public IncomeDTO()
        {
            this.Observation = string.Empty;
        }

        public Income ToEntity()
        {
            return new Income()
            {
                Type = Type,
                Observation = Observation,
            };
        }
    }
}
